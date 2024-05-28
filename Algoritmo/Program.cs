using Algoritmo;
using Algoritmo.Models.Entities;

ScedbContext context = new();
AlgoritmoPro algoritmo = new(context);

var gruposPorCalendarizar =algoritmo.GetGrupoPeriodo(2203);
var FechasXTurnos = algoritmo.FechasByTurno(2203);

foreach (var grupo in gruposPorCalendarizar.OrderBy(x=>x.Value.Count()))
{
	foreach (var materia in grupo.Value)
	{
		
		if(materia.Bloque == "Matutino")
		{

		} else if (materia.Bloque == "Vespertino")
		{

		}
		else
		{

		}
	}
}






Console.WriteLine();