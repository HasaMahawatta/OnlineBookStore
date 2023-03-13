using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBookStore.Models
{
	// reserve details model
	public class ReserveDetails
	{
		[Key]
		public string ReserveId { get; set; }

		public string BookId { get; set; }

		public Book Books { get; set; }
	}
}