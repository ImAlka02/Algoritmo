using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class Carrera
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Letra { get; set; }

    public virtual ICollection<CarreraConEdificio> CarreraConEdificio { get; set; } = new List<CarreraConEdificio>();

    public virtual ICollection<Grupo> Grupo { get; set; } = new List<Grupo>();
}
