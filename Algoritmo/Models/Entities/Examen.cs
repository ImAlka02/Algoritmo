using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Examen
{
    public int Id { get; set; }

    public int GrupoId { get; set; }

    public int AulaId { get; set; }

    public int PeriodoId { get; set; }

    public int FechaConHoraId { get; set; }

    public virtual Aula Aula { get; set; } = null!;

    public virtual FechaConHora FechaConHora { get; set; } = null!;

    public virtual Grupo Grupo { get; set; } = null!;

    public virtual Periodo Periodo { get; set; } = null!;
}
