using Algoritmo;
using Algoritmo.Models.Entities;

ScedbContext context = new();
AlgoritmoPro algoritmo = new(context);

var gruposPorCalendarizar =algoritmo.GetGrupoPeriodo(2203);

foreach (var grupo in gruposPorCalendarizar.OrderBy(x=>x.Value.Count()))
{

}

var owo = algoritmo.xs(2203);

Console.WriteLine();