using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarksCRMApp.Model;
using MarksCRMApp.Service;

namespace MarksCRMApp.Controllers
{
    public class NoteController : Controller
    {

        //initialize service object
        INoteService _NoteService;

        public NoteController(INoteService NoteService)
        {
            _NoteService = NoteService;
        }

        //
        // GET: /Note/
        [Authorize]
        public ActionResult Index()
        {
            return View(_NoteService.GetAll());
        }

        //
        // GET: /Note/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Note/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Note note)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _NoteService.Create(note);
                return RedirectToAction("Index");
            }
            return View(note);

        }

        //
        // GET: /Note/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Note note = _NoteService.GetById(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        //
        // POST: /Note/Edit
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Note note)
        {

            if (ModelState.IsValid)
            {
                _NoteService.Update(note);
                return RedirectToAction("Index");
            }
            return View(note);

        }

        //
        // GET: /Note/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Note note = _NoteService.GetById(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        //
        // POST: /Note/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection data)
        {
            Note note = _NoteService.GetById(id);
            _NoteService.Delete(note);
            return RedirectToAction("Index");
        }
    }
}
