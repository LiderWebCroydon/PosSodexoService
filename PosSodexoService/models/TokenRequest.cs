using System;
using System.Text.Json.Serialization;

[Serializable]
public class TokenRequest
{
    [JsonPropertyName("cuc")]
    public string cuc { get; set; }
    [JsonPropertyName("usuario")]
    public string usuario { get; set; }
    [JsonPropertyName("contrasenia")]
    public string contrasenia { get; set; }
}
