using Algoritmo;
using Algoritmo.Models.Entities;
using System;
using System.Runtime.CompilerServices;

ScedbContext context = new();
AlgoritmoPro algoritmo = new(context);

var gruposPorCalendarizar = algoritmo.GetGrupoPeriodo(2241);
var FechasXTurnos = algoritmo.FechasByTurno(2241);
var random = new Random();

foreach (var paquete in gruposPorCalendarizar.OrderBy(x => x.Value.Count()))
{
	foreach (var grupo in paquete.Value)
	{
        var fechasPosibles = FechasXTurnos[grupo.Bloque].ToList();
        var fechasNoDisponiblesGrupo = algoritmo.FechasNoDisponibles(grupo);
        var fechasNoDisponiblesMaestro = algoritmo.FechasNoDisponiblesxMaestro(grupo);
        var fechasNoDisponiblesAula = algoritmo.FechasNoDisponiblesxAula(grupo);

       
        var fechasNoDisponibles = fechasNoDisponiblesGrupo
            .Concat(fechasNoDisponiblesMaestro)
            .Concat(fechasNoDisponiblesAula)
            .Distinct()
            .ToList();

       
        foreach (var fecha in fechasNoDisponibles)
        {
            fechasPosibles.Remove(fecha);
        }

        var aulasDisponibles = algoritmo.ObtenerAulasDisponibles(grupo);

        while (fechasPosibles.Count > 0)
        {
            
            int fechaIndex = random.Next(fechasPosibles.Count);
            var fechaSeleccionada = fechasPosibles[fechaIndex];
            fechasPosibles.RemoveAt(fechaIndex);

            bool examenAsignado = false;

  
            if (!string.IsNullOrEmpty(grupo.Aula))
            {
               
                var aulaEspecificada = aulasDisponibles.FirstOrDefault(a => a.Nombre == grupo.Aula.ToUpper());

                if (aulaEspecificada != null && algoritmo.AulaDisponibleEnFecha(aulaEspecificada.Id, fechaSeleccionada.FechaHasHoraId))
                {
                    
                    var examen = new Examen
                    {
                        GrupoId = grupo.Id,
                        AulaId = aulaEspecificada.Id,
                        PeriodoId = grupo.PeriodoId,
                        FechaConHoraId = fechaSeleccionada.FechaHasHoraId
                    };

                    context.Examen.Add(examen);
                    context.SaveChanges();

                
                    aulasDisponibles.Remove(aulaEspecificada);
                    examenAsignado = true;
                }
            }

            if (!examenAsignado)
            {
               
                foreach (var aula in aulasDisponibles.ToList())
                {
                    if (algoritmo.AulaDisponibleEnFecha(aula.Id, fechaSeleccionada.FechaHasHoraId))
                    {
                        
                        var examen = new Examen
                        {
                            GrupoId = grupo.Id,
                            AulaId = aula.Id,
                            PeriodoId = grupo.PeriodoId,
                            FechaConHoraId = fechaSeleccionada.FechaHasHoraId
                        };

                        context.Examen.Add(examen);
                        context.SaveChanges();

                        
                        aulasDisponibles.Remove(aula);
                        examenAsignado = true;
                        break;
                    }
                }
            }

            
            if (examenAsignado)
            {
                break;
            }
        }
    }
}






Console.WriteLine("ya acabó el algoritmo");