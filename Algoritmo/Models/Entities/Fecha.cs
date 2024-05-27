using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Fecha
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int PeriodoId { get; set; }

    public virtual ICollection<FechaConHora> FechaConHora { get; set; } = new List<FechaConHora>();

    public virtual Periodo Periodo { get; set; } = null!;
}
