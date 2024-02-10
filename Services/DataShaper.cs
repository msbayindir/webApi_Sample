using System.Dynamic;
using System.Reflection;
using Services.Contract;

namespace Services;

public class DataShaper<T>:IDataShaper<T>
where T:class
{
    public PropertyInfo[] Properties { get; set; }

    public DataShaper()
    {
        Properties = typeof(T)
            .GetProperties(BindingFlags.Public|BindingFlags.Instance);
    }
    public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldString)
    {
        var requiredProperty = GetRequiredField(fieldString);
        return FetchDataForEntities(entities, requiredProperty);

    }

    public ExpandoObject ShapeData(T entity, string fieldString)
    {
        var requiredProperty = GetRequiredField(fieldString);
        return FetchDataForEntity(entity, requiredProperty);
    }

    private IEnumerable<PropertyInfo> GetRequiredField(string fieldString)
    {
        var requiredField = new List<PropertyInfo>();
        if (!String.IsNullOrWhiteSpace(fieldString))
        {
            var fields = fieldString.Split(",",StringSplitOptions.RemoveEmptyEntries);
            foreach (var value in fields)
            {
                PropertyInfo property = Properties
                    .FirstOrDefault(pi => pi
                        .Name
                        .Equals(value.Trim(), StringComparison.InvariantCultureIgnoreCase));
                if (property is null)continue;
                requiredField.Add(property);
            }
        }
        else
        {
            requiredField = Properties.ToList();
        }

        return requiredField;
    }

    private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo> propertyInfos)
    {
        var shapeDataObject = new ExpandoObject();
        foreach (var pi in propertyInfos)
        {
            var objectValue = pi.GetValue(entity);
            shapeDataObject.TryAdd(pi.Name, objectValue);
        }

        return shapeDataObject;
    }
    
    private IEnumerable<ExpandoObject> FetchDataForEntities(IEnumerable<T> entities, IEnumerable<PropertyInfo> propertyInfos)
    {

        var eObjectList = new List<ExpandoObject>();
        foreach (var value in entities)
        {
            eObjectList.Add(FetchDataForEntity(value,propertyInfos));
        }

        return eObjectList;
    }
}