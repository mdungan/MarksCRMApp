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
    public class CustomerController : Controller
    {
        ICustomerService _CustomerService;
        IStateService _StateService;
        INoteService _NoteService;
        public CustomerController(ICustomerService CustomerService, IStateService StateService, INoteService NoteService)
        {
            _CustomerService = CustomerService;
            _StateService = StateService;
            _NoteService = NoteService;
        }

        // GET: /Customer/
        [Authorize]
        public ActionResult Index()
        {
            return View(_CustomerService.GetAll());
        }

        // GET: /Customer/Details/5
        [Authorize]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _CustomerService.GetById(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Customer/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(_StateService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,CompanyName,EmailAddress,Address,StateId,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _CustomerService.Create(customer);
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(_StateService.GetAll(), "Id", "Name", customer.StateId);
            return View(customer);
        }

        // POST: /Customer/CreateNote
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CreateNote([Bind(Include = "CustomerId,Body")] Note note)
        {
            if (ModelState.IsValid)
            {
                _NoteService.Create(note);
                return RedirectToAction("Index");
            }
            Customer customer = _CustomerService.GetById(note.CustomerId);
            customer.Notes = _NoteService.GetByCustomerId(note.CustomerId);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(_StateService.GetAll(), "Id", "Name", customer.StateId);
            return View(customer);
        }

        // GET: /Customer/Edit/5
        [Authorize]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _CustomerService.GetById(id.Value);
            customer.Notes = _NoteService.GetByCustomerId(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(_StateService.GetAll(), "Id", "Name", customer.StateId);
            return View(customer);
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,CompanyName,EmailAddress,Address,StateId,PhoneNumber,Notes")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //foreach (var note in customer.Notes)
                //{
                //    _NoteService.Create(note);
                //}
                _CustomerService.Update(customer);
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(_StateService.GetAll(), "Id", "Name", customer.StateId);
            return View(customer);
        }

        // GET: /Customer/Delete/5
        [Authorize]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _CustomerService.GetById(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(long id)
        {
            Customer customer = _CustomerService.GetById(id);
            _CustomerService.Delete(customer);
            return RedirectToAction("Index");
        }
    }
}
