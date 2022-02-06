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
    public class ProducersController : Controller
    {
		private readonly IProducerService _producerService;

		public ProducersController(IProducerService producerService)
		{
			_producerService = producerService;
		}

		public async Task<IActionResult> Index()
		{
			var producers = await _producerService.GetAllAsync();
			return View(producers);
		}

		// GET: producers/details/{id}

		public async Task<IActionResult> Details(int id)
		{
			var producers = await _producerService.GetByIdAsync(id);
			if (producers == null) return View("NotFound");
			return View(producers);
		}

		public IActionResult Create()
		{
			return View();
		}

		// POST: producers/create
		[HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Producer producer)
		{
			if (!ModelState.IsValid)
			{
				return View(producer);
			}
			await _producerService.AddAsync(producer);
			return RedirectToAction(nameof(Index));
		}

		// GET: Actors/Edit/{id}
		public async Task<IActionResult> Edit(int id)
		{
			var producerDetails = await _producerService.GetByIdAsync(id);

			if (producerDetails == null)
			{
				return View("NotFound");
			}
			return View(producerDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
		{
			if (!ModelState.IsValid)
			{
				return View(producer);
			}
			await _producerService.UpdateAsync(id, producer);
			return RedirectToAction(nameof(Index));
		}

		// GET: Actors/Delete/{id}
		public async Task<IActionResult> Delete(int id)
		{
			var producerDetails = await _producerService.GetByIdAsync(id);

			if (producerDetails == null)
			{
				return View("NotFound");
			}
			return View(producerDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var actorDetails = await _producerService.GetByIdAsync(id);

			if (actorDetails == null)
			{
				return View("NotFound");
			}

			await _producerService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

	}
}
