using AutoMapper;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Services
{
	public class OrdersService : IOrdersService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public OrdersService(
			AppDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
		{
			var orders = await _context.Orders
							.Include(o => o.OrderItems)
							.ThenInclude(o => o.Movie)
							.Include(o => o.User)
							.ToListAsync();

			if (userRole != "Admin")
            {
				orders = orders.Where(n => n.UserId == userId).ToList();
            }

			return orders;
		}

		public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail)
		{
			var order = new Order()
			{
				UserId = userId,
				Email = userEmail
			};

			await _context.Orders.AddAsync(order);
			await _context.SaveChangesAsync();

			var orderItems = _mapper.Map<List<OrderItem>>(items);

            foreach (var orderItem in orderItems)
            {
				orderItem.OrderId = order.Id;
            }

			await _context.OrderItems.AddRangeAsync(orderItems);
			await _context.SaveChangesAsync();
		}
	}
}
