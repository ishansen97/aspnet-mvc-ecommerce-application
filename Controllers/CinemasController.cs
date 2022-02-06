using ETicketsStore.Data;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Controllers
{
	public class CinemasController : Controller
	{
		private readonly ICinemaService _cinemaService;

		public CinemasController(ICinemaService cinemaService)
		{
			_cinemaService = cinemaService;
		}

		public async Task<IActionResult> Index()
		{
			var cinemas = await _cinemaService.GetAllAsync();
			return View(cinemas);
		}

		// GET: cinemas/create
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return View(cinema);
			}
			await _cinemaService.AddAsync(cinema);
			return RedirectToAction(nameof(Index));
		}
	}
}
