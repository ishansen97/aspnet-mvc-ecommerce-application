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

		public void Add(Actor entity)
		{
			_context.Actor.Add(entity);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Actor>> GetAll()
		{
			var actors = await _context.Actor.ToListAsync();
			return actors;
		}

		public Actor GetById(int id)
		{
			var actor = _context.Actor.Where(a => a.Id == id).FirstOrDefault();
			return actor;
		}

		public Actor Update(int id, Actor newEntity)
		{
			return default;
		}
	}
}
