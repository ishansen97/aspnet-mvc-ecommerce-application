using ETicketsStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Models
{
    public class Actor : IEntityBase
    {
		[Key]
		public int Id { get; set; }

		[Display(Name = "Profile Picture")]
		[Required(ErrorMessage = "Profile Picture URL is required")]
		public string ProfilePictureURL { get; set; }

		[Display(Name = "Full Name")]
		[Required(ErrorMessage = "Full name is required")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "The full name must be within 3 and 50 characters")]
		public string FullName { get; set; }

		[Display(Name = "Bio")]
		[Required(ErrorMessage = "Bio is required")]
		public string Bio { get; set; }

		// Relationships
		public List<ActorMovie> ActorMovies { get; set; }
	}
}
