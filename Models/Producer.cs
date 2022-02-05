using ETicketsStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Models
{
    public class Producer : IEntityBase
    {
		[Key]
		public int Id { get; set; }

		[Display(Name = "Profile Picture")]
		public string ProfilePictureURL { get; set; }

		[Display(Name = "Full Name")]
		public string FullName { get; set; }

		[Display(Name = "Bio")]
		public string Bio { get; set; }

		// Relationships
		public List<Movie> Movies { get; set; }
	}
}
