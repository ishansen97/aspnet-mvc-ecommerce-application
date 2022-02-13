using ETicketsStore.Data.Cart;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Data.Static;
using ETicketsStore.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ETicketsStore.Controllers
{
	[Authorize]
	public class OrdersController : Controller
	{
		private readonly IMovieService _movieService;
		private readonly ShoppingCart _shoppingCart;
		private readonly IOrdersService _ordersService;

		public OrdersController(IMovieService movieService, ShoppingCart shoppingCart, IOrdersService ordersService)
		{
			_movieService = movieService;
			_shoppingCart = shoppingCart;
			_ordersService = ordersService;
		}

		public async Task<IActionResult> Index()
		{
			string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
			string userRole = User.FindFirstValue(ClaimTypes.Role);
			var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
			return View(orders);
		}

		public IActionResult ShoppingCart()
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

		public async Task<RedirectToActionResult> AddToShoppingCart(int id)
		{
			var movie = await _movieService.GetMovieByIdAsync(id);
			if (movie != null)
			{
				_shoppingCart.AddItemToCart(movie);
			}

			return RedirectToAction(nameof(ShoppingCart));
		}

		public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
		{
			var movie = await _movieService.GetMovieByIdAsync(id);
			if (movie != null)
			{
				_shoppingCart.RemoveItemFromCart(movie);
			}

			return RedirectToAction(nameof(ShoppingCart));
		}

		public async Task<IActionResult> CompleteOrder()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			string userEmail = User.FindFirstValue(ClaimTypes.Email);

			await _ordersService.StoreOrderAsync(items, userId, userEmail);
			await _shoppingCart.ClearShoppingCartAsync();
			return View("OrderCompleted");
		}

	}
}
