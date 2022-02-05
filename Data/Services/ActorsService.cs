using ETicketsStore.Data.Base;
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
	public class ActorsService : EntityBaseRepository<Actor>, IActorsService
	{

		public ActorsService(AppDbContext context) : base(context)
		{
		}
	}
}
