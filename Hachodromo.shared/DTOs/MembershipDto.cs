using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hachodromo.shared.DTOs
{
	public class MembershipDto
	{
		public string MembershipType { get; set; } // Tipo de membresía
		public DateTime StartDate { get; set; } // Fecha de inicio
		public DateTime ExpirationDate { get; set; }
	}
}
