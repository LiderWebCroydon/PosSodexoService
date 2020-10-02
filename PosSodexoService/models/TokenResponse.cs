using System;

[Serializable]
public class TokenResponse
{
    public string token { get; set; }
    public object descripcion { get; set; }
    public int pSalida { get; set; }
}
