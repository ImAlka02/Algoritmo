using Algoritmo;
using Algoritmo.Models.Entities;

ScedbContext context = new();
AlgoritmoPro algoritmo = new(context);

var gruposPorCalendarizar =algoritmo.GetGrupoPeriodo(2203);
var FechasXTurnos = algoritmo.FechasByTurno(2203);

foreach (var paquete in gruposPorCalendarizar.OrderBy(x=>x.Value.Count()))
{
	foreach (var grupo in paquete.Value)
	{
		var fechasPosibles = FechasXTurnos[grupo.Bloque].ToList();


	}
}






Console.WriteLine();