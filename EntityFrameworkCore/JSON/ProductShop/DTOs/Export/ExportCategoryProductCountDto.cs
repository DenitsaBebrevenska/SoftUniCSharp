using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;
public class ExportCategoryProductCountDto
{
    [JsonProperty("category")]
    public string Name { get; set; } = null!;

    public int ProductsCount { get; set; }

    public string AveragePrice { get; set; } = null!;

    public string TotalRevenue { get; set; } = null!;
}
