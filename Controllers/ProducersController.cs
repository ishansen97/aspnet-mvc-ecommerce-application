using ETicketsStore.Data;
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
        private readonly AppDbContext _context;

		public ProducersController(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var producers = await _context.Producer.ToListAsync();
			return View(producers);
		}
	}
}
