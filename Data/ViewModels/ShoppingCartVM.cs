using ETicketsStore.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.ViewModels
{
    public class ShoppingCartVM
    {
		public ShoppingCart ShoppingCart { get; set; }

		public double ShoppingCartTotal { get; set; }
	}
}
