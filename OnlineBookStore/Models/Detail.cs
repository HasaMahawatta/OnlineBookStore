using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookStore.Models
{
	//properties for the reservations
	public class Detail
	{
		public string BookId { get; set; }
		public string BookTitle { get; set; }
		public string ReservedId { get; set; }
	}
}