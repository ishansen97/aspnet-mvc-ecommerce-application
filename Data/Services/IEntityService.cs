using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Services
{
    public interface IEntityService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        T GetById(int id);

        void Add(T entity);

        T Update(int id, T newEntity);

        void Delete(int id);
    }
}
