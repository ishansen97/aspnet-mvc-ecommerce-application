using ETicketsStore.Models;
using Microsoft.EntityFrameworkCore;
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

		public ShoppingCart(AppDbContext context)
		{
			_context = context;
		}

		public string ShoppingCartId { get; set; }

		public List<ShoppingCartItem> ShoppingCartItems { get; set; }

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
