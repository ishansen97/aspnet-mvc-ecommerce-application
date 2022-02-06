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
		[Required(ErrorMessage = "Name is required")]
		[Display(Name = "Movie Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Description is required")]
		[Display(Name = "Movie Description")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Price is required")]
		[Display(Name = "Movie Price in $")]
		public double Price { get; set; }

		[Required(ErrorMessage = "Movie Poster URL is required")]
		[Display(Name = "Movie Poster URL")]
		public string ImageURL { get; set; }

		[Required(ErrorMessage = "Start date is required")]
		[Display(Name = "Start date")]
		public DateTime StartDate { get; set; }

		[Required(ErrorMessage = "End date is required")]
		[Display(Name = "End date")]
		public DateTime EndDate { get; set; }

		[Required(ErrorMessage = "Movie category is required")]
		[Display(Name = "Select category")]
		public MovieCategory MovieCategory { get; set; }

		#region Relationships
		[Required(ErrorMessage = "Movie actor(s) is required")]
		[Display(Name = "Select Actor(s)")]
		public List<int> ActorIds { get; set; }

		[Required(ErrorMessage = "Cinema is required")]
		[Display(Name = "Select a cinema")]
		public int CinemaId { get; set; }

		[Required(ErrorMessage = "Movie producer is required")]
		[Display(Name = "Select a producer")]
		public int ProducerId { get; set; }
		#endregion
	}
}
