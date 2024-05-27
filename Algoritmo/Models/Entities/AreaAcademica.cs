using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class AreaAcademica
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Maestro> Maestro { get; set; } = new List<Maestro>();
}
