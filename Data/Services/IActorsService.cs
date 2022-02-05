using ETicketsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllAsync();

        Task<Actor> GetByIdAsync(int id);

        Task AddAsync(Actor entity);

        Task<Actor> UpdateAsync(int id, Actor newEntity);

        Task DeleteAsync(int id);
    }
}
