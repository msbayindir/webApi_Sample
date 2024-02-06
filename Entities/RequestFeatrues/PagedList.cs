namespace Entities.RequestFeatrues;

public class PagedList<T>:List<T>
{
    public MetaData MetaData { get; set; }

    public PagedList(IEnumerable<T>items,int count,int pageSize,int pageNumber )
    {
        MetaData = new()
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPage = (int)Math.Ceiling(count / (decimal)pageSize)

        };
        AddRange(items);
    }

    public static PagedList<T> ToPagedList(IEnumerable<T> source,int pageNumber,int pageSize)
    {
        var count = source.Count();
        var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        return new PagedList<T>(items, count, pageSize, pageNumber);
    }
}