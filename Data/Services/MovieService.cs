using ETicketsStore.Data.Base;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Services
{
	public class MovieService : EntityBaseRepository<Movie>, IMovieService
	{
		private readonly AppDbContext _context;

		public MovieService(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Movie> GetMovieByIdAsync(int id)
		{
			var movieDetails = _context.Movie
								.Include(m => m.Cinema)
								.Include(m => m.Producer)
								.Include(m => m.ActorMovies).ThenInclude(a => a.Actor)
								.FirstOrDefaultAsync(m => m.Id == id);
			return await movieDetails;
		}
	}
}
