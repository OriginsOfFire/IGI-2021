using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WEB_953501_KUZAUKOU.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("guitarId")]
        public int GuitarId { get; set; }
        [JsonPropertyName("guitarName")]
        public string GuitarName { get; set; }
    }
}
