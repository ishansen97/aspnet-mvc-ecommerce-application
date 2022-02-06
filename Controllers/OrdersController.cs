using ETicketsStore.Data.Cart;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicketsStore.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IMovieService _movieService;
		private readonly ShoppingCart _shoppingCart;

		public OrdersController(IMovieService movieService, ShoppingCart shoppingCart)
		{
			_movieService = movieService;
			_shoppingCart = shoppingCart;
		}

		public IActionResult Index()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;

			var response = new ShoppingCartVM()
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};

			return View(response);
		}
	}
}
