using ETicketsStore.Data;
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
		private readonly AppDbContext _context;

		public MoviesController(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var movies = await _context
								.Movie
								.Include(m => m.Cinema)
								.OrderBy(m => m.Name)
								.ToListAsync();
			return View(movies);
		}
	}
}
