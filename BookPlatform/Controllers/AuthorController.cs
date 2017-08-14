using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookPlatform.Context;
using BookPlatform.Models;
using BookPlatform.Repositories;

namespace BookPlatform.Controllers
{
    public class AuthorController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new BookContext());

        // GET: Author
        public ActionResult Index()
        {
            IEnumerable<Author> authors = _unitOfWork.Authors.GetAll();

            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            Author author = _unitOfWork.Authors.Get(id);

            return View(author);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
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

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            Author author = _unitOfWork.Authors.Get(id);
            
            return View(author);
        }

        // POST: Author/Edit/5
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

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            Author author = _unitOfWork.Authors.Get(id);

            _unitOfWork.Authors.Remove(author);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}
