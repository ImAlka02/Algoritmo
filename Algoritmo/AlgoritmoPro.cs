﻿using Algoritmo.Models.DTOs;
using Algoritmo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo
{
	public class AlgoritmoPro
	{
		private readonly ScedbContext context;

		public AlgoritmoPro(ScedbContext context)
		{
			this.context = context;
		}

		public Dictionary<string, List<Grupo>>? GetGrupoPeriodo(int periodo)
		{
			//var gruposExamen = context.Grupo.Include(x=>x.Examen).Where(x=> x.TieneExamen == 1 && x.PeriodoId == periodo && x.Examen.Count == 0 ).GroupBy(x => x.Nombre);
			//return gruposExamen.ToDictionary<string,Grupo>(x=>x.Nombre, x=>x);

			var gruposExamen = context.Grupo
			   .Include(x => x.Examen)
			   .Where(x => x.TieneExamen == 1 && x.PeriodoId == periodo && x.Examen.Count == 0)
			   .GroupBy(x => x.Nombre);

			// Convierte los grupos a un diccionario usando el primer elemento de cada grupo
			var diccionarioGrupos = gruposExamen.ToDictionary(
				g => g.Key,            // Utiliza el nombre del grupo como clave
				g => g.ToList() // Toma el primer grupo en cada agrupación
			);

			return diccionarioGrupos;
		}

		public Dictionary<string, List<FechaCalendarizadaDTO>> FechasByTurno(int periodo)
		{


			var turnosByfechas = context.FechaConHora.Where(x => x.Fecha.PeriodoId == periodo)
				.GroupBy(x => new
				{
					Id = x.HoraId,
					Turno = x.Hora.Descripcion
				})
				.Select(x => new TurnoDTO()
				{
					Id = x.Key.Id,
					Turno = x.Key.Turno,
					Fechas = x.Select(x => new FechaCalendarizadaDTO()
					{
						Id = x.FechaId,
						FechaHasHoraId = x.Id,
						Fecha = x.Fecha.Descripcion
					}).ToList()
				});

			var bloquesByTurno = new Dictionary<string, List<FechaCalendarizadaDTO>>();

			string key = "";

			foreach (var turno in turnosByfechas)
			{
				switch (int.Parse(turno.Turno.Substring(0, 2)))
				{
					case < 11:
						key = "Matutino";
						break;
					case >= 11 and <= 14:
						key = "Intermedio";
						break;
					case > 14:
						key = "Vespertino";
						break;
				}

				if (bloquesByTurno.ContainsKey(key))
				{
					bloquesByTurno[key].AddRange(turno.Fechas);
				}
				else
				{
					bloquesByTurno.Add(key, turno.Fechas);
				}

			}

			return bloquesByTurno;
		}

		public List<FechaCalendarizadaDTO> FechasNoDisponibles(Grupo grupo)
		{
			// Deberia eliminar fechas en donde ya tenga el mismo grupo un examen calendarizado
			// Deberia tener en cuenta tambien los grupos compartidos 

			return context.Examen
			   .Include(x => x.FechaConHora)
			   .Where(x => x.GrupoId == grupo.Id)
			   .Select(x => new FechaCalendarizadaDTO()
			   {
				   Id = x.FechaConHoraId,
				   Fecha = x.FechaConHora.Fecha.Descripcion,
				   FechaHasHoraId = x.FechaConHoraId
			   }).ToList();
		}
		public List<FechaCalendarizadaDTO> FechasNoDisponiblesxMaestro(Grupo grupo)
		{
			return context.Examen.Include(x => x.FechaConHora).Where(x => x.Grupo.MaestroId == grupo.MaestroId).Select(x => new FechaCalendarizadaDTO()
			{
				Id = x.FechaConHoraId,
				Fecha = x.FechaConHora.Fecha.Descripcion,
				FechaHasHoraId = x.FechaConHoraId
			}).ToList();
		}
        public List<FechaCalendarizadaDTO> FechasNoDisponiblesxAula(Grupo grupo)
        {
            var aula = context.Aula.FirstOrDefault(a => a.Nombre == grupo.Aula);
            if (aula == null)
            {
                
                return new List<FechaCalendarizadaDTO>();
            }
            return context.Examen
                .Include(x => x.FechaConHora)
                .Where(x => x.AulaId == aula.Id)
                .Select(x => new FechaCalendarizadaDTO()
                {
                    Id = x.FechaConHoraId,
                    Fecha = x.FechaConHora.Fecha.Descripcion,
                    FechaHasHoraId = x.FechaConHoraId
                }).ToList();
        }
        public List<Aula> ObtenerAulasDisponibles(Grupo grupo)
        {
            var carreraId = grupo.CarreraId;
            var edificioIds = context.CarreraConEdificio
                .Where(ce => ce.CarreraId == carreraId)
                .Select(ce => ce.EdificioId)
                .ToList();

            return context.Aula
                .Where(a => edificioIds.Contains(a.EdificioId))
                .ToList();
        }
        public bool AulaDisponibleEnFecha(int aulaId, int fechaConHoraId)
        {
            return !context.Examen
                .Any(e => e.AulaId == aulaId && e.FechaConHoraId == fechaConHoraId);
        }
        //public List<FechaCalendarizadaDTO> FechasNoDisponiblesAula(Grupo grupo)
        //{
        //	return context.Examen.Include(x => x.FechaConHora).Where(x=>x.);
        //});



    }
}
