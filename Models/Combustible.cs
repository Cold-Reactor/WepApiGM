using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WepApiGM.Models;

public partial class Combustible
{
    public int IdCombustible { get; set; }

    public string Tipo { get; set; } = null!;

    public double Precio { get; set; }
    [JsonIgnore]
    public virtual ICollection<Transporte> Transporte { get; set; } = new List<Transporte>();
}
