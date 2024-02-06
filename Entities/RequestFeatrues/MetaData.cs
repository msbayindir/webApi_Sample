namespace Entities.RequestFeatrues;

public class MetaData
{
    public int CurrentPage { get; set; }
    public int TotalPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public bool HasNextPage => CurrentPage < TotalPage;
    public bool HasPrevPage => CurrentPage > 1;
}