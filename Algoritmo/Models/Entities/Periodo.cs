using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Periodo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Examen> Examen { get; set; } = new List<Examen>();

    public virtual ICollection<Fecha> Fecha { get; set; } = new List<Fecha>();

    public virtual ICollection<Grupo> Grupo { get; set; } = new List<Grupo>();
}
