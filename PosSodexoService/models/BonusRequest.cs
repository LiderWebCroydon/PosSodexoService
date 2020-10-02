

using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[Serializable]
public class BonusRequest
{
    [JsonPropertyName("cuc")]
    public string cuc { get; set; }
    [JsonPropertyName("idTerminal")]
    public string idTerminal { get; set; }
    [JsonPropertyName("idEmisorBono")]
    public string idEmisorBono { get; set; }
    [JsonPropertyName("codigoBono")]
    public string codigoBono { get; set; }
    [JsonPropertyName("medioLectura")]
    public string medioLectura { get; set; }
}
