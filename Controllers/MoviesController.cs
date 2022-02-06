using ETicketsStore.Data;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicketsStore.Data.ViewModels;

namespace ETicketsStore.Controllers
{
	public class MoviesController : Controller
	{
		private readonly IMovieService _movieService;

		public MoviesController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public async Task<IActionResult> Index()
		{
			var movies = await _movieService.GetAllAsync(m => m.Cinema);
			return View(movies);
		}

		public async Task<IActionResult> Filter(string searchString)
		{
			var movies = await _movieService.GetAllAsync(m => m.Cinema);
			if (!string.IsNullOrEmpty(searchString))
			{
				var filteredResults = movies.Where(movie =>
										movie.Name.Contains(searchString) ||
										movie.Description.Contains(searchString))
									.ToList();

				return View("Index", filteredResults);
			}

			return View("Index", movies);
		}



		// GET: Movies/Details/{id}
		public async Task<IActionResult> Details(int id)
		{
			var movieDetail = await _movieService.GetMovieByIdAsync(id);
			if (movieDetail == null) return View("NotFound");
			return View(movieDetail);
		}

		// GET: Movies/Create
		public async Task<IActionResult> Create()
		{
			await LoadViewBagData();

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Create(NewMovieVM newMovie)
		{
			if (!ModelState.IsValid)
			{
				await LoadViewBagData();

				return View(newMovie);
			}
			await _movieService.AddNewMovieAsync(newMovie);
			return RedirectToAction(nameof(Index));
		}

		// GET: Movies/Edit/{id}
		public async Task<IActionResult> Edit(int id)
		{
			var movieDetails = await _movieService.GetMovieByIdAsync(id);
			if (movieDetails == null) return View("NotFound");

			// TODO: use AutoMapper for mapping
			var response = new NewMovieVM()
			{
				Id = movieDetails.Id,
				Name = movieDetails.Name,
				Description = movieDetails.Description,
				Price = movieDetails.Price,
				StartDate = movieDetails.StartDate,
				EndDate = movieDetails.EndDate,
				ImageURL = movieDetails.ImageURL,
				MovieCategory = movieDetails.MovieCategory,
				CinemaId = movieDetails.CinemaId,
				ProducerId = movieDetails.ProducerId,
				ActorIds = movieDetails.ActorMovies.Select(am => am.ActorId).ToList()
			};

			await LoadViewBagData();

			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, NewMovieVM movie)
		{
			if (id != movie.Id) return View("NotFound");
			if (!ModelState.IsValid)
			{
				await LoadViewBagData();

				return View(movie);
			}
			await _movieService.UpdateMovieAsync(movie);
			return RedirectToAction(nameof(Index));
		}



		#region Internal Helper methods
		private async Task LoadViewBagData()
		{
			var dropdownData = await _movieService.GetNewMovieDropdownValues();
			NewMovieDropdownsVM b = null;

			ViewBag.Cinemas = new SelectList(dropdownData.Cinemas, "Id", "Name");
			ViewBag.Producers = new SelectList(dropdownData.Producers, "Id", "FullName");
			ViewBag.ActorIds = new SelectList(dropdownData.Actors, "Id", "FullName");
		}
		#endregion
	}
}
