using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Models
{
    public class Producer
    {
		[Key]
		public int Id { get; set; }

		public string ProfilePictureURL { get; set; }

		public string FullName { get; set; }

		public string Bio { get; set; }

		// Relationships
		public List<Movie> Movies { get; set; }
	}
}
