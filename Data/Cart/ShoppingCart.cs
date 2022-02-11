using ETicketsStore.Data.Base;
using ETicketsStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Cart
{
    public class ShoppingCart
    {
		public AppDbContext _context { get; set; }

		public string ShoppingCartId { get; set; }

		public List<ShoppingCartItem> ShoppingCartItems { get; set; }

		public ShoppingCart(AppDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieve the shopping cart from the user session
		/// </summary>
		/// <param name="services">Service Provider</param>
		/// <returns>The shoppingcart instance</returns>
		public static ShoppingCart GetShoppingCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<AppDbContext>();

			string cartId = session.GetString(Constants.CART_ID) ?? Guid.NewGuid().ToString();
			session.SetString(Constants.CART_ID, cartId);

			return new ShoppingCart(context) { ShoppingCartId = cartId };
		}

		public List<ShoppingCartItem> GetShoppingCartItems()
		{
			return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
															.Where(n => n.ShoppingCartId == ShoppingCartId)
															.Include(n => n.Movie)
															.ToList());
		}

		public double GetShoppingCartTotal()
		{
			var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
									.Select(n => n.Movie.Price * n.Amount)
									.Sum();
			return total;
		}

		public void AddItemToCart(Movie movie)
		{
			var shoppingCartItem = _context.ShoppingCartItems
										.FirstOrDefault(sh => sh.Movie.Id == movie.Id &&
																sh.ShoppingCartId == ShoppingCartId);

			if (shoppingCartItem == null)
			{
				shoppingCartItem = new ShoppingCartItem()
				{
					ShoppingCartId = ShoppingCartId,
					Movie = movie,
					Amount = 1
				};

				_context.ShoppingCartItems.Add(shoppingCartItem);
			}
			else
			{
				shoppingCartItem.Amount++;
			}

			_context.SaveChanges();
		}

		public void RemoveItemFromCart(Movie movie)
		{
			var shoppingCartItem = _context.ShoppingCartItems
										.FirstOrDefault(sh => sh.Movie.Id == movie.Id &&
																sh.ShoppingCartId == ShoppingCartId);

			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Amount > 1)
				{
					shoppingCartItem.Amount--;
				}
				else
				{
					_context.ShoppingCartItems.Remove(shoppingCartItem);
				}

			}

			_context.SaveChanges();
		}

	}
}
