﻿using ETicketsStore.Data;
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
        private readonly AppDbContext _context;

		public CinemasController(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var cinemas = await _context.Cinema.ToListAsync();
			return View(cinemas);
		}
	}
}