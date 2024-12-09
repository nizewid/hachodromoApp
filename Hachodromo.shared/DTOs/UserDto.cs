using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hachodromo.shared.DTOs
{
	public class UserDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string City { get; set; }
		public int Region { get; set; }
		public bool IsActive { get; set; }
		public string UserType { get; set; } // Simplificado, en vez de incluir el objeto completo de UserType
		public MembershipDto Membership { get; set; } // Relación con MembershipDto
	}

}
