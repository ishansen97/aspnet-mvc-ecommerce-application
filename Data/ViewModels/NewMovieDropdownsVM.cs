using ETicketsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.ViewModels
{
	/// <summary>
	/// View model for the <see cref="Movie">.
	/// </summary>
    public class NewMovieDropdownsVM
    {
		public NewMovieDropdownsVM()
		{
			Producers = new List<Producer>();
			Cinemas = new List<Cinema>();
			Actors = new List<Actor>();
		}

		public List<Producer> Producers { get; set; }

		public List<Cinema> Cinemas { get; set; }

		public List<Actor> Actors { get; set; }
	}
}
