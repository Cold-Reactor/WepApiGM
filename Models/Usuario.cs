using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WepApiGM.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Name { get; set; } = null!;

    public string Pass { get; set; } = null!;
}
