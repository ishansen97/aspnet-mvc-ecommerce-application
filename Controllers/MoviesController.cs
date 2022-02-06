using ETicketsStore.Data;
using ETicketsStore.Data.Services.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

		// GET: Movies/Details/{id}
		public async Task<IActionResult> Details(int id)
		{
			var movieDetail = await _movieService.GetMovieByIdAsync(id);
			if (movieDetail == null) return View("NotFound");
			return View(movieDetail);
		}

		// GET: Movies/Create
		public IActionResult Create()
		{
			ViewData["Welcome"] = "Welcome to our store";
			ViewBag.Description = "This is the store description";
			return View();
		}
	}
}
