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
		//reserving a book
		public ActionResult Reserve(String id)
		{
			var data = _context.Books.Where(x => x.BookID == id).FirstOrDefault();
			if (data != null)
			{
				data.IsReserved = true;
				_context.SaveChanges();

				ReserveDetails reserveDetail = new ReserveDetails();
				reserveDetail.ReserveId = Guid.NewGuid().ToString();
				reserveDetail.BookId = id;
				reserveDetail.Books = data;
				_context.ReserveDetails.Add(reserveDetail);
				_context.SaveChanges();

				ViewBag.Message = "Book Reserved Sucessfully";

			}
			return RedirectToAction("index");

		}
		//get reserve details
		[HttpGet]
		public ActionResult Detail(String id)
		{
			var data = _context.Books.Where(x => x.BookID == id).FirstOrDefault();
			var reserve = _context.ReserveDetails.Where(x => x.BookId == id).FirstOrDefault();
			//object to pass reserve details to view
			Detail obj = new Detail();  

			obj.BookTitle = data.BookTitle;
			obj.BookId = id;
			if (reserve != null)
			{
				obj.ReservedId = reserve.ReserveId;
			}
			return View(obj);
		}
		//delete data
		public ActionResult Delete(string id)
		{
			var data = _context.Books.Where(x => x.BookID == id).FirstOrDefault();
			_context.Books.Remove(data);
			_context.SaveChanges();
			ViewBag.Message = "Data Removed Succesfully";
			return RedirectToAction("index");
		}


	}
}