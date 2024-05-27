using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Materia
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public virtual ICollection<Grupo> Grupo { get; set; } = new List<Grupo>();
}
