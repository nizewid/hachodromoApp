using Microsoft.EntityFrameworkCore;
using Hachodromo.Shared.Models; // Ajusta según la ubicación de tus modelos.

namespace HachodromoApi.Data
{
	public class HachodromoDbContext : DbContext
	{
		public HachodromoDbContext(DbContextOptions<HachodromoDbContext> options)
			: base(options)
		{ }
		public void Seed()
		{
			if(!UserTypes.Any())
			{
				var userType = new UserType
				{
					Name = "SuperAdmin",
					Description = "Administrador del sistema"
				};
				UserTypes.Add(userType);
				SaveChanges();
			}
			if (!Users.Any())
			{
				var UserType = UserTypes.FirstOrDefault(u => u.Name == "SuperAdmin");

				var User = new User
				{
					FirstName = "Jose Gregorio",
					LastName = "Flores",
					LastName2 = "Silva",
					BornDate = new DateTime(1989, 9, 19),
					Sex = Hachodromo.shared.Constants.SexCode.Male,
					City = "Gijon",
					Region = Hachodromo.Shared.Constants.Region.Asturias,
					Email = "admin@admin.com",
					PasswordHash = "12345678",
					CreatedAt = DateTime.Now,
					LastLogin = DateTime.Now,
					IsActive = true,
					UserTypeId = UserType.Id,
					MembershipExpirationDate = new DateTime(2024, 12, 31)
				};
				Users.Add(User);
				SaveChanges();
			}
			
		}


		public DbSet<User> Users { get; set; }
		public DbSet<UserType> UserTypes { get; set; }
		public DbSet<Membership> Memberships { get; set; }
	}
}
