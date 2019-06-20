using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace chefs_dishes.Models
{
	public class Dish
	{
		[Key]
		public int DishId { get; set; }
		public string Name { get; set; }
		public int ChefId { get; set; }
		public Chef ChefLink { get; set; }// foreign key
		public int Tastiness { get; set; }
		public int Calories { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdateAt { get; set; } = DateTime.Now;
	}
}