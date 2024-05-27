using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Configuracion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contrasena { get; set; } = null!;
}
