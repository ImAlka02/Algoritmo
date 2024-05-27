using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Aula
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int? TipoAulaId { get; set; }

    public int EdificioId { get; set; }

    public virtual Edificio Edificio { get; set; } = null!;

    public virtual ICollection<Examen> Examen { get; set; } = new List<Examen>();

    public virtual TipoAula? TipoAula { get; set; }
}
