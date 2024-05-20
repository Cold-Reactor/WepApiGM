using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WepApiGM.Models;

public partial class Tarifa
{
    public int IdTarifa { get; set; }

    public int IdTransporte { get; set; }

    public int IdCaseta { get; set; }

    public int Precio { get; set; }
    [JsonIgnore]
    public virtual Caseta IdCasetaNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Transporte IdTransporteNavigation { get; set; } = null!;
}
