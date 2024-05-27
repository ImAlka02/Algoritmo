using System;
using System.Collections.Generic;

namespace Algoritmo.Models.Entities;

public partial class CarreraConEdificio
{
    public int Id { get; set; }

    public int CarreraId { get; set; }

    public int EdificioId { get; set; }

    public virtual Carrera Carrera { get; set; } = null!;

    public virtual Edificio Edificio { get; set; } = null!;
}
