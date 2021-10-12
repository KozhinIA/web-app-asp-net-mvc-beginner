using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcBeginner.Models;

namespace WebAppAspNetMvcBeginner.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new LibraryContext();
            var books = db.Books.ToList();

            return View(books);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var book = new Book();

            return View(book);
        }

        [HttpPost]
        public ActionResult Create(Book model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new LibraryContext();
            model.CreateAt = DateTime.Now;

            db.Books.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/Books/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new LibraryContext();
            var book = db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return RedirectPermanent("/Books/Index");

            db.Books.Remove(book);
            db.SaveChanges();

            return RedirectPermanent("/Books/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new LibraryContext();
            var book = db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return RedirectPermanent("/Books/Index");

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book model)
        {
            var db = new LibraryContext();
            var book = db.Books.FirstOrDefault(x => x.Id == model.Id);
            if (book == null)
                ModelState.AddModelError("Id", "Книга не найдена");

            if (!ModelState.IsValid)
                return View(model);

            MappingBook(model, book);

            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Books/Index");
        }

        private void MappingBook(Book sourse, Book destination)
        {
            destination.Name = sourse.Name;
            destination.Author = sourse.Author;
            destination.Isbn = sourse.Isbn;
            destination.Year = sourse.Year;
        }
    }
}