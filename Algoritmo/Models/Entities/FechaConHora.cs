using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class FechaConHora
{
    public int Id { get; set; }

    public int HoraId { get; set; }

    public int FechaId { get; set; }

    public virtual ICollection<Examen> Examen { get; set; } = new List<Examen>();

    public virtual Fecha Fecha { get; set; } = null!;

    public virtual Hora Hora { get; set; } = null!;
}
