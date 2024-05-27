using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Grupo
{
    public int Id { get; set; }

    public sbyte TieneExamen { get; set; }

    public string Aula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int MaestroId { get; set; }

    public int PeriodoId { get; set; }

    public int MateriaId { get; set; }

    public int? GrupoCompartidoId { get; set; }

    public int CarreraId { get; set; }

    public string Bloque { get; set; } = null!;

    public virtual Carrera Carrera { get; set; } = null!;

    public virtual ICollection<Examen> Examen { get; set; } = new List<Examen>();

    public virtual Grupo? GrupoCompartido { get; set; }

    public virtual ICollection<Grupo> InverseGrupoCompartido { get; set; } = new List<Grupo>();

    public virtual Maestro Maestro { get; set; } = null!;

    public virtual Materia Materia { get; set; } = null!;

    public virtual Periodo Periodo { get; set; } = null!;
}
