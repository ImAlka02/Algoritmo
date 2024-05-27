using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Hora
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<FechaConHora> FechaConHora { get; set; } = new List<FechaConHora>();
}
