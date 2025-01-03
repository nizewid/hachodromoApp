﻿using Hachodromo.Shared.Models;
using Hachodromo.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace HachodromoApi.Data
{
	public class HachodromoDbContext(DbContextOptions<HachodromoDbContext> options) : DbContext(options)
	{
		public void Seed()
		{
			if (!UserTypes.Any())
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
					Sex = SexCode.Male,
					City = "Gijon",
					Region = Region.Asturias,
					Email = "admin@admin.com",
					PasswordHash = "12345678",
					CreatedAt = DateTime.Now,
					LastLogin = DateTime.Now,
					IsActive = true,
					UserTypeId = UserType.Id,
				};
				Users.Add(User);
				SaveChanges();
			}

		}


		public DbSet<User> Users { get; set; } = null!;
		public DbSet<UserType> UserTypes { get; set; } = null!;
		public DbSet<Membership> Memberships { get; set; } = null!;
	}
}
