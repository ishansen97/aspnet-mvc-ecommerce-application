﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.ViewModels
{
    public class LoginVM
    {
		[Display(Name = "Email address")]
		public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
	}
}
