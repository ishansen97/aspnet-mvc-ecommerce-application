using ETicketsStore.Data;
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
		private readonly AppDbContext _context;

		public ActorsController(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}

		public async Task<IActionResult> Index()
		{
			var data = await _context.Actor.ToListAsync();
			return View(data);
		}
	}
}
