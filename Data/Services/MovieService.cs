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
	public class MovieService : EntityBaseRepository<Movie>, IMovieService
	{
		public MovieService(AppDbContext context) : base(context)
		{
		}
	}
}
