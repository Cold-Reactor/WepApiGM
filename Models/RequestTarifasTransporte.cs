namespace WepApiGM.Models
{
    public class RequestTarifasTransporte
    {
        public int IdCaseta { get; set; }
        public List<RequestTransportePrecio> TransporteTarifa { get; set; }
    }
}
