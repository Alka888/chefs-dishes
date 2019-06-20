using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chefs_dishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace chefs_dishes.Controllers
{
	public class HomeController : Controller
	{
		private MyContext dbContext;

		public HomeController(MyContext context)
		{
			dbContext = context;
		}
///////////////index page///////////////
		[Route("")]
		[HttpGet]
		public IActionResult Index()
		{
			List<Chef> AllChefs = dbContext.Chefs.Include(dish => dish.listOfDishes).ToList();
			ViewBag.allChefs = AllChefs;
			return View();
		}

///////////////showing dishes///////////////////
		[Route("Dishes")]
		[HttpGet]
		public IActionResult Dishes()
		{
			List<Dish> AllDishes = dbContext.Dishes.Include(chef => chef.ChefLink).ToList();
			ViewBag.allDishes = AllDishes;
			return View();
		}

//////////////showing chefs page view///////////////
		[HttpGet]
		[Route("AddChefView")]

		public IActionResult AddChefView()
		{
			return View("AddChef");
		}

//////////////////button AddChef/////////////
		[HttpPost("AddChef")]
		public IActionResult AddChef(Chef chef)
		{
			if (ModelState.IsValid)
			{
				if (chef.Birthday >= DateTime.Today)
				{
					ModelState.AddModelError("Birthday", "Birthday must be from the past!");
					return View("AddChef");
				}
				dbContext.Add(chef);
				dbContext.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("AddChef");
			}
		}
//////////////showing Dishpage view//////////////////////
		[HttpGet]
		[Route("AddDishView")]

		public IActionResult AddDishView()
		{
			return View("AddDish");
		}

/////////////////button AddDish//////////////////////
		[HttpPost("AddDish")]
		public IActionResult AddDish(Dish dish)
		{
			if (ModelState.IsValid)
			{

				dbContext.Add(dish);
				dbContext.SaveChanges();
				return RedirectToAction("Dishes");
			}
			else
			{
				List<Chef> AllChefs = dbContext.Chefs.ToList();
				ViewBag.allChefs = AllChefs;
				return View("AddDishView");
			}
		}

	}
}
