using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookPlatform.Context;
using BookPlatform.Models;
using BookPlatform.Repositories;

namespace BookPlatform.Controllers
{
    public class BookController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new BookContext());
        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<Book> books = _unitOfWork.Books.GetAll();

            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = _unitOfWork.Books.Get(id);

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = _unitOfWork.Books.Get(id);

            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = _unitOfWork.Books.Get(id);

            _unitOfWork.Books.Remove(book);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}
