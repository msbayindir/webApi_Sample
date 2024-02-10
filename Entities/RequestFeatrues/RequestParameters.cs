namespace Entities.RequestFeatrues;

public abstract class RequestParameters
{
    private const int maxPageSize = 50;
    public int PageNumber { get; set; }
    private int _pageSize;

    public int PageSize { 
    get
    {
        return _pageSize;
    }
    set
    {
        _pageSize = value>maxPageSize? maxPageSize:value;
    } }

    public string? OrderBy { get; set; }
    public String? Fields { get; set; }
    
}