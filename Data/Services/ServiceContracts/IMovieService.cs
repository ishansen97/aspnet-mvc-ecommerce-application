﻿using ETicketsStore.Data.Base;
using ETicketsStore.Data.ViewModels;
using ETicketsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Services.ServiceContracts
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropdownsVM> GetNewMovieDropdownValues();

        Task AddNewMovieAsync(NewMovieVM data);

		Task UpdateMovieAsync(NewMovieVM movie);
	}
}
