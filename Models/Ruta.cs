using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WepApiGM.Models;

public partial class Ruta
{
    public int IdRuta { get; set; }

    public string Name { get; set; } = null!;

    public decimal Kilometros { get; set; }
    [JsonIgnore]
    public virtual ICollection<Ruta_caseta> RutaCaseta { get; set; } = new List<Ruta_caseta>();
    [JsonIgnore]
    public virtual ICollection<Viaje_ruta> ViajeRuta { get; set; } = new List<Viaje_ruta>();
}
