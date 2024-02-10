using System.Dynamic;

namespace Services.Contract;

public interface IDataShaper<T>
{
    IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities,string fieldString);
    ExpandoObject ShapeData(T entity,string fieldString);

}