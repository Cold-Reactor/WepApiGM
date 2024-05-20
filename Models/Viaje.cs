using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WepApiGM.Models;

public partial class Viaje
{
    public int IdViaje { get; set; }

    public DateTime FechaPartida { get; set; }

    public DateTime? FechaRegreso { get; set; }

    public bool Tipo { get; set; }

    public int Viaticos { get; set; }

    public int Pasajeros { get; set; }
    [JsonIgnore]
    public virtual ICollection<Viaje_ruta> ViajeRuta { get; set; } = new List<Viaje_ruta>();
}
