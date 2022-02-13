using ETicketsStore.Data;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Data.Static;
using ETicketsStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Controllers
{
	[Authorize(Roles = UserRoles.Admin)]
	public class CinemasController : Controller
	{
		private readonly ICinemaService _cinemaService;

		public CinemasController(ICinemaService cinemaService)
		{
			_cinemaService = cinemaService;
		}

		[AllowAnonymous]
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

		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
		{
			var cinemas = await _cinemaService.GetByIdAsync(id);
			if (cinemas == null) return View("NotFound");
			return View(cinemas);
		}

		// GET: Actors/Edit/{id}
		public async Task<IActionResult> Edit(int id)
		{
			var cinemaDetails = await _cinemaService.GetByIdAsync(id);

			if (cinemaDetails == null)
			{
				return View("NotFound");
			}
			return View(cinemaDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return View(cinema);
			}
			await _cinemaService.UpdateAsync(id, cinema);
			return RedirectToAction(nameof(Index));
		}

		// GET: Actors/Delete/{id}
		public async Task<IActionResult> Delete(int id)
		{
			var producerDetails = await _cinemaService.GetByIdAsync(id);

			if (producerDetails == null)
			{
				return View("NotFound");
			}
			return View(producerDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var actorDetails = await _cinemaService.GetByIdAsync(id);

			if (actorDetails == null)
			{
				return View("NotFound");
			}

			await _cinemaService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

	}
}
