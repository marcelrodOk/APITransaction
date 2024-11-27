using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Model.Entities
{
	public class TransactionTC
	{
		[Key]
		public int Id { get; set; }
		public string CodEnte { get; set; } = null!;

		public string NroUsuario { get; set; } = null!;

		public string Aacc { get; set; } = null!;

		public string? CodOblig { get; set; }

		public string? FechaVto { get; set; }

		public string? Importe { get; set; }

		public string? ImporteFact { get; set; }

		public byte? DigVer { get; set; }

		public string? Tipo { get; set; }

		public string? FechaProrroga { get; set; }

		public string FechaPago { get; set; } = null!;

		public string? FechaProceso { get; set; }

		public string CodAutorizacion { get; set; } = null!;

		public string? NroTarjeta { get; set; }

		public string HoraPago { get; set; } = null!;

		public string? TipoTarjeta { get; set; }

		public long NroTransaccion { get; set; }

		public string? FechaCierre { get; set; }

		public string? FechaEnvioWeb { get; set; }

		public string? FechaRend { get; set; }

		public string? FechaHoraPublicacion { get; set; }

		public short? CantCuotas { get; set; }

		public string? IndicadorLifore { get; set; }

		public string? ImporteTotalAutorizado { get; set; }

		public decimal? Comprobante { get; set; }

		public decimal? RefNumber { get; set; }
	}
}
