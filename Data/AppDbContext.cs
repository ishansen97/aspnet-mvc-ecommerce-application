using ETicketsStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ActorMovie>().HasKey(am => new { am.ActorId, am.MovieId });

			modelBuilder.Entity<ActorMovie>().HasOne(a => a.Actor).WithMany(am => am.ActorMovies).HasForeignKey(a => a.ActorId);
			modelBuilder.Entity<ActorMovie>().HasOne(m => m.Movie).WithMany(am => am.ActorMovies).HasForeignKey(a => a.MovieId);

			base.OnModelCreating(modelBuilder);
		}

		#region DbSets
		public DbSet<Actor> Actor { get; set; }

		public DbSet<Movie> Movie { get; set; }

		public DbSet<Producer> Producer { get; set; }

		public DbSet<Cinema> Cinema { get; set; }

		public DbSet<ActorMovie> ActorMovie { get; set; }


		// order related tables
		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

		#endregion
	}
}
