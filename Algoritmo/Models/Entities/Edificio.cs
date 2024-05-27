using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Edificio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Aula> Aula { get; set; } = new List<Aula>();

    public virtual ICollection<CarreraConEdificio> CarreraConEdificio { get; set; } = new List<CarreraConEdificio>();
}
