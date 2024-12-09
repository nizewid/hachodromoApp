using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HachodromoApi.Data;  // Asegúrate de que esta referencia esté correcta
using Hachodromo.Shared.Models;
using Hachodromo.shared.DTOs;

namespace HachodromoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly HachodromoDbContext _context;

		// Constructor que inyecta el DbContext
		public UserController(HachodromoDbContext context)
		{
			_context = context;
		}

		// GET: api/User
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
		{
			var users = await _context.Users
				.Include(u => u.UserType)
				.Include(u => u.Membership)
				.ToListAsync();

			var userDtos = users.Select(u => new UserDto
			{
				Id = u.Id,
				FirstName = u.FirstName,
				LastName = u.LastName,
				Email = u.Email,
				City = u.City,
				Region = (int)u.Region,
				IsActive = u.IsActive,
				UserType = u.UserType.Name,
				Membership = u.Membership.FirstOrDefault() == null ? null : new MembershipDto
				{
					MembershipType = u.Memberships.FirstOrDefault().MembershipType,
					ExpirationDate = u.Memberships.FirstOrDefault().ExpirationDate
				}
			}).ToList();

			return Ok(userDtos);
		}

		// GET api/User/5
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUser(int id)
		{
			// Busca un usuario por su ID e incluye UserType y Membership
			var user = await _context.Users
				.Include(u => u.UserType)
				.Include(u => u.Membership)
				.FirstOrDefaultAsync(u => u.Id == id);

			if (user == null)
			{
				return NotFound(); // Si no se encuentra, devuelve 404
			}

			return Ok(user);
		}


		// POST api/User
		[HttpPost]
		[Route("api/User")]
		public IActionResult CreateUser([FromBody] User user)
		{
			if (user == null)
				return BadRequest("Invalid user data.");

			_context.Users.Add(user);
			_context.SaveChanges();
			return Ok(user);
		}
		// PUT api/User/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutUser(int id, User user)
		{
			if (id != user.Id)
			{
				return BadRequest(); // Si el ID no coincide, devuelve 400
			}

			_context.Entry(user).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent(); // Devuelve 204 si la operación es exitosa
		}

		// DELETE api/User/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user == null)
			{
				return NotFound(); // Si el usuario no se encuentra, devuelve 404
			}

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

			return NoContent(); // Devuelve 204 después de eliminar
		}
	}
}
