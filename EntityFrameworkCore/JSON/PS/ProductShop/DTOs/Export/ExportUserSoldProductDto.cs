using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;
public class ExportUserSoldProductDto
{
    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [JsonProperty("lastName")]
    public string LastName { get; set; } = null!;

    [JsonProperty("soldProducts")]
    public ICollection<ExportSoldProductDto> SoldProducts { get; set; }
}
