using ETicketsStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Services
{
	//public class ActorsService : IEntityService<Actor>
	public class ActorsService : IActorsService
	{
		private readonly AppDbContext _context;

		public ActorsService(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Actor entity)
		{
			await _context.Actor.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var actor = await _context.Actor.FirstOrDefaultAsync(a => a.Id == id);
			_context.Actor.Remove(actor);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Actor>> GetAllAsync()
		{
			var actors = await _context.Actor.ToListAsync();
			return actors;
		}

		public async Task<Actor> GetByIdAsync(int id)
		{
			var actor = await _context.Actor.FirstOrDefaultAsync(a => a.Id == id);
			return actor;
		}

		public async Task<Actor> UpdateAsync(int id, Actor newEntity)
		{
			_context.Update(newEntity);
			await _context.SaveChangesAsync();
			return newEntity;
		}
	}
}
