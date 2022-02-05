using ETicketsStore.Data;
using ETicketsStore.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicketsStore.Controllers
{
	public class ActorsController : Controller
	{
		private readonly ActorsService _actorService;

		public ActorsController(ActorsService actorService)
		{
			_actorService = actorService;
		}

		public async Task<IActionResult> Index()
		{
			var data = await _actorService.GetAll();
			return View(data);
		}
	}
}
