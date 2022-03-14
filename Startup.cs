using ETicketsStore.Data;
using ETicketsStore.Data.Cart;
using ETicketsStore.Data.Services;
using ETicketsStore.Data.Services.ServiceContracts;
using ETicketsStore.Data.Validation;
using ETicketsStore.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicketsStore
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// configuring fluent validation.
			services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MoviesValidator>());

			// configuring Db Context
			services.AddDbContext<AppDbContext>(options => 
													options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

			// configuring services
			services.AddScoped<IActorsService, ActorsService>();
			services.AddScoped<IProducerService, ProducerService>();
			services.AddScoped<ICinemaService, CinemaService>();
			services.AddScoped<IMovieService, MovieService>();
			services.AddScoped<IOrdersService, OrdersService>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

			// Authentication and Authorization
			services.AddIdentity<ApplicationUser, IdentityRole>(config => 
			{
				config.Password.RequiredLength = 4;
				config.Password.RequireDigit = false;
				config.Password.RequireNonAlphanumeric = false;
				config.Password.RequireUppercase = false;
				//config.SignIn.RequireConfirmedEmail = true;
			})
			.AddEntityFrameworkStores<AppDbContext>();

			services.AddSession();
			services.AddMemoryCache();
			services.AddAuthentication(options => 
			{
				options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			});


			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseSession();

			// Authentication and Authorization
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			// initialize the database with data.
			//AppDbInitializer.Seed(app);
			//AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
		}
	}
}
