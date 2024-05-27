using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class TipoAula
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Aula> Aula { get; set; } = new List<Aula>();
}
