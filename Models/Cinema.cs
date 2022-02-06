using ETicketsStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Models
{
    public class Cinema : IEntityBase
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Logo is required")]
		public string Logo { get; set; }

		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; }

		// Relationships
		public List<Movie> Movies { get; set; }
	}
}
