using ETicketsStore.Data.Base;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Services
{
	public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
	{
		public CinemaService(AppDbContext context) : base(context)
		{
		}
	}
}
