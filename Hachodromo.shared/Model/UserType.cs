using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hachodromo.Shared.Models
{
	public class UserType
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; } // Ejemplo: "Admin", "Superadmin", "Client", etc.

		[MaxLength(200)]
		public string Description { get; set; } // Descripción de lo que puede hacer ese tipo de usuario
	}
}
