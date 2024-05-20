using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WepApiGM.Models;

public partial class Caseta
{
    public int IdCaseta { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Ruta_caseta> RutaCaseta { get; set; } = new List<Ruta_caseta>();
    [JsonIgnore]
    public virtual ICollection<Tarifa> Tarifa { get; set; } = new List<Tarifa>();
}
