using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo.Models.DTOs
{
	public class TurnoDTO
	{
		public int Id { get; set; }
		public string Turno { get; set; } = null!;
		public List<FechaCalendarizadaDTO> Fechas { get; set; } = null!;
	}

	public class FechaCalendarizadaDTO
	{
		public int Id { get; set; }
		public string Fecha { get; set; } = null!;
		public int FechaHasHoraId { get; set; }
	}
}
