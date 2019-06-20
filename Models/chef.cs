using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace chefs_dishes.Models
{
	public class Chef
	{	
		[Key]
		public int ChefId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Birthday { get; set; }
		public int Age 
		{ 
			get {return DateTime.Now.Year - Birthday.Year;} 
		}
		public int Number { get; set; }
		public List<Dish> listOfDishes { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdateAt { get; set; } = DateTime.Now;
	}
	

}