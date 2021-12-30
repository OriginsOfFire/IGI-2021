using System.Text.Json.Serialization;
namespace WEB_953501_KUZAUKOU.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("guitarName")]
        public string GuitarName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("strings")]
        public int Strings { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
