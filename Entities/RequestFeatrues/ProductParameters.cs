namespace Entities.RequestFeatrues;

public class ProductParameters : RequestParameters
{
    public uint MinPrice  { get; set; }
    public uint MaxPrice { get; set; } = 1000;
    public bool ValidPriceRange => MaxPrice > MinPrice;
    public String? SearchTerm { get; set; }
}