using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookStore.Controllers
{
	public class HomeController : Controller

	{
		//Get Database object
		ApplicationDbContext _context = new ApplicationDbContext();
		public ActionResult Index(string search)
		{
			//list all books
			//search books by BookTitle or BookID 
			var listOfData = _context.Books.Where(book => book.BookTitle.StartsWith(search) || search == null || book.BookID.StartsWith(search)).ToList();
			return View(listOfData);
		}
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		//add Books
		[HttpPost]
		public ActionResult Create(Book book)
		{
			
			_context.Books.Add(book);
			_context.SaveChanges();
			ViewBag.Message = "Book Inserted Successfully";
			return RedirectToAction("index");
		}


	}
}