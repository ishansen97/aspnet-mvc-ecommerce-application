using ETicketsStore.Data.Base;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Data.ViewModels;
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

		public async Task AddNewMovieAsync(NewMovieVM data)
		{
			var newMovie = new Movie()
			{
				Name = data.Name,
				Description = data.Description,
				Price = data.Price,
				ImageURL = data.ImageURL,
				CinemaId = data.CinemaId,
				StartDate = data.StartDate,
				EndDate = data.EndDate,
				MovieCategory = data.MovieCategory,
				ProducerId = data.ProducerId
			};

			await _context.Movie.AddAsync(newMovie);
			await _context.SaveChangesAsync();

			// Add movie actors
			foreach (var actorId in data.ActorIds)
			{
				var newActorMovie = new ActorMovie()
				{
					ActorId = actorId,
					MovieId = newMovie.Id
				};

				await _context.ActorMovie.AddAsync(newActorMovie);
			}
			await _context.SaveChangesAsync();
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

		public async Task<NewMovieDropdownsVM> GetNewMovieDropdownValues()
		{
			var response = new NewMovieDropdownsVM
			{
				Actors = await _context.Actor.OrderBy(a => a.FullName).ToListAsync(),
				Cinemas = await _context.Cinema.OrderBy(a => a.Name).ToListAsync(),
				Producers = await _context.Producer.OrderBy(a => a.FullName).ToListAsync()
			};

			return response;
		}

		public async Task UpdateMovieAsync(NewMovieVM data)
		{
			var dbMovie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == data.Id);

			if (dbMovie != null)
			{
				dbMovie.Name = data.Name;
				dbMovie.Description = data.Description;
				dbMovie.Price = data.Price;
				dbMovie.ImageURL = data.ImageURL;
				dbMovie.CinemaId = data.CinemaId;
				dbMovie.StartDate = data.StartDate;
				dbMovie.EndDate = data.EndDate;
				dbMovie.MovieCategory = data.MovieCategory;
				dbMovie.ProducerId = data.ProducerId;

				await _context.SaveChangesAsync();
			}

			// removing exsiting actors
			var existingActors = _context.ActorMovie.Where(a => a.MovieId == data.Id).ToList();
			_context.ActorMovie.RemoveRange(existingActors);
			await _context.SaveChangesAsync();

			// Add movie actors
			foreach (var actorId in data.ActorIds)
			{
				var newActorMovie = new ActorMovie()
				{
					ActorId = actorId,
					MovieId = data.Id
				};

				await _context.ActorMovie.AddAsync(newActorMovie);
			}
			await _context.SaveChangesAsync();

		}
	}
}
