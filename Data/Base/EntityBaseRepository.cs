﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Base
{
	public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
	{
		private readonly AppDbContext _context;

		public EntityBaseRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
			EntityEntry entityEntry = _context.Entry<T>(entity);
			entityEntry.State = EntityState.Deleted;
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync() =>  await _context.Set<T>().ToListAsync();
		
		public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);

		public async Task<T> UpdateAsync(int id, T newEntity)
		{
			EntityEntry entityEntry = _context.Entry<T>(newEntity);
			entityEntry.State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return newEntity;
		}
	}
}
