using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Maestro
{
    public int Id { get; set; }

    public string Rfc { get; set; } = null!;

    public string Numerocontrol { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public int AreaAcademicaId { get; set; }

    public virtual AreaAcademica AreaAcademica { get; set; } = null!;

    public virtual ICollection<Grupo> Grupo { get; set; } = new List<Grupo>();
}
