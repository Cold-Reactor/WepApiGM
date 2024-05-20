using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WepApiGM.Models;

public partial class Viaje_ruta
{
    public int IdViajeRuta { get; set; }

    public int IdViaje { get; set; }

    public int IdRuta { get; set; }

    public bool? Ida { get; set; }

    public bool? Regreso { get; set; }
    [JsonIgnore]
    public virtual Ruta IdRutaNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Viaje IdViajeNavigation { get; set; } = null!;
}
