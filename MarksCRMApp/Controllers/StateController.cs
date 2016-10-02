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
    public class StateController : Controller
    {

        //initialize service object
        IStateService _StateService;

        public StateController(IStateService StateService)
        {
            _StateService = StateService;
        }

        //
        // GET: /State/
        [Authorize]
        public ActionResult Index()
        {
            return View(_StateService.GetAll());
        }

        //
        // GET: /State/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /State/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(State state)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _StateService.Create(state);
                return RedirectToAction("Index");
            }
            return View(state);

        }

        //
        // GET: /State/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            State state = _StateService.GetById(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        //
        // POST: /State/Edit
        [HttpPost]
        [Authorize]
        public ActionResult Edit(State state)
        {

            if (ModelState.IsValid)
            {
                _StateService.Update(state);
                return RedirectToAction("Index");
            }
            return View(state);

        }

        //
        // GET: /State/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            State state = _StateService.GetById(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        //
        // POST: /State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id, FormCollection data)
        {
            State state = _StateService.GetById(id);
            _StateService.Delete(state);
            return RedirectToAction("Index");
        }
    }

}
