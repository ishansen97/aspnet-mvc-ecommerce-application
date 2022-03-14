using ETicketsStore.Data;
using ETicketsStore.Data.Base;
using ETicketsStore.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.ViewModels
{
	public class NewMovieVM
	{
		public int Id { get; set; }

		// TODO: Use Fluent Validation for validation purposes
		[Display(Name = "Movie Name")]
		public string Name { get; set; }

		[Display(Name = "Movie Description")]
		public string Description { get; set; }

		[Display(Name = "Movie Price in $")]
		public double Price { get; set; }

		[Display(Name = "Movie Poster URL")]
		public string ImageURL { get; set; }

		[Display(Name = "Start date")]
		public DateTime StartDate { get; set; }

		[Display(Name = "End date")]
		public DateTime EndDate { get; set; }

		[Display(Name = "Select category")]
		public MovieCategory MovieCategory { get; set; }

		#region Relationships
		[Display(Name = "Select Actor(s)")]
		public List<int> ActorIds { get; set; }

		[Display(Name = "Select a cinema")]
		public int CinemaId { get; set; }

		[Display(Name = "Select a producer")]
		public int ProducerId { get; set; }
		#endregion
	}
}
