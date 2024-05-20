using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WepApiGM.Models;

public partial class Ruta_caseta
{
    public int IdRutaCaseta { get; set; }

    public int IdRuta { get; set; }

    public int IdCaseta { get; set; }
    [JsonIgnore]
    public virtual Caseta IdCasetaNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Ruta IdRutaNavigation { get; set; } = null!;
}
