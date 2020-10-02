using System;
using System.Runtime.Serialization;

[Serializable]
public class BonusResponse
{
    
    public object codigo { get; set; }
    
    public string estadoBono { get; set; }
    
    public string valorBono { get; set; }
    
    public int pSalida { get; set; }
    
    public string terminal { get; set; }
    
    public string cuc { get; set; }
    
    public object nroAprobacion { get; set; }
    
    public object nroBono { get; set; }
    
    public object tipoBono { get; set; }
    
    public object tipoProducto { get; set; }
    
    public int codTipoBono { get; set; }
    
    public int codTipoProducto { get; set; }
    
    public object idReembolso { get; set; }
    
    public string descripcion { get; set; }
}
