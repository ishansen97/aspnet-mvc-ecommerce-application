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
		#region DbSets
		public DbSet<Actor> Actors;

		public DbSet<Movie> Movies;

		public DbSet<Producer> Producers;

		public DbSet<Cinema> Cinemas;

		public DbSet<ActorMovie> ActorMovies;

		#endregion

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
	}
}
