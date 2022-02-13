using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Models
{
    public class OrderItem
    {
		[Key]
		public int Id { get; set; }

		public int Amount { get; set; }

		public double Price { get; set; }

		public int MovieId { get; set; }

		[ForeignKey("MovieId")]
		public Movie Movie { get; set; }

		public int OrderId { get; set; }

		[ForeignKey("OrderId")]
		public Order Order { get; set; }


	}
}
