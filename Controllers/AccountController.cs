using AutoMapper;
using ETicketsStore.Data;
using ETicketsStore.Data.Static;
using ETicketsStore.Data.ViewModels;
using ETicketsStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicketsStore.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public AccountController(UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			AppDbContext context,
			IMapper mapper)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
			_mapper = mapper;
		}

		public IActionResult Register()
		{
			return View(new RegisterVM());
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVM)
        {
			if (!ModelState.IsValid)
            {
				return View(registerVM);
            }

			var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
			if (user != null)
            {
				TempData["Error"] = "This email address is already in use";
				return View(registerVM);
			}

			/*var newUser = new ApplicationUser()
			{
				FullName = registerVM.FullName,
				Email = registerVM.EmailAddress,
				UserName = registerVM.EmailAddress
			};*/

			var newUser = _mapper.Map<ApplicationUser>(registerVM);

			var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

			if (newUserResponse.Succeeded)
            {
				await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

			return View("RegisterCompleted");
		}

		public async Task<IActionResult> Users()
        {
			var users = await _context.Users.ToListAsync();
			return View(users);
        }

		public IActionResult Login()
		{
			var response = new LoginVM();
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{
			if (!ModelState.IsValid)
			{
				return View(loginVM);
			}

			var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

			if (user != null)
			{
				var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
				if (passwordCheck)
				{
					var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index", "Movies");
					}
				}

				TempData["Error"] = "Wrong credentials, Please try again!";
				return View(loginVM);
			}

			TempData["Error"] = "Wrong credentials, Please try again!";
			return View(loginVM);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
        {
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Movies");
        }

		public IActionResult AccessDenied(string returnUrl)
        {
			return View();
        }


	}
}
