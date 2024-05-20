using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WepApiGM.Models;

public partial class Transporte
{
    public int IdTransporte { get; set; }

    public string Name { get; set; } = null!;

    public int IdCombustible { get; set; }

    public int Ejes { get; set; }
    [JsonIgnore]
    public virtual Combustible IdCombustibleNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Tarifa> Tarifa { get; set; } = new List<Tarifa>();
}
