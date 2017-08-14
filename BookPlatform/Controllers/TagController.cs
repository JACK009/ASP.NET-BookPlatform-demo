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
    public class TagController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new BookContext());

        // GET: Tag
        public ActionResult Index()
        {
            IEnumerable<Tag> tags = _unitOfWork.Tags.GetAll();

            return View(tags);
        }

        // GET: Tag/Details/5
        public ActionResult Details(int id)
        {
            Tag tag = _unitOfWork.Tags.Get(id);

            return View(tag);
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
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

        // GET: Tag/Edit/5
        public ActionResult Edit(int id)
        {
            Tag tag = _unitOfWork.Tags.Get(id);

            return View(tag);
        }

        // POST: Tag/Edit/5
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

        // GET: Tag/Delete/5
        public ActionResult Delete(int id)
        {
            Tag tag = _unitOfWork.Tags.Get(id);

            _unitOfWork.Tags.Remove(tag);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}
