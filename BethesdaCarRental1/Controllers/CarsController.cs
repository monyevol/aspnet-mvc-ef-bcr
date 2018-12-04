using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BethesdaCarRental1.Models;

namespace BethesdaCarRental1.Controllers
{
    public class CarsController : Controller
    {
        private BethesdaCarRentalEntities db = new BethesdaCarRentalEntities();

        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            List<SelectListItem> types = new List<SelectListItem>();
            List<SelectListItem> conditions = new List<SelectListItem>();
            List<SelectListItem> availabilities = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "SUV", Value = "SUV" });
            types.Add(new SelectListItem() { Text = "Compact", Value = "Compact" });
            types.Add(new SelectListItem() { Text = "Economy", Value = "Economy" });
            types.Add(new SelectListItem() { Text = "Mini Van", Value = "Mini Van" });
            types.Add(new SelectListItem() { Text = "Standard", Value = "Standard" });
            types.Add(new SelectListItem() { Text = "Full Size", Value = "Full Size" });
            types.Add(new SelectListItem() { Text = "Pickup Truck", Value = "Pickup Truck" });
            types.Add(new SelectListItem() { Text = "Passenger Van", Value = "Passenger Van" });

            availabilities.Add(new SelectListItem() { Text = "Other", Value = "Other" });
            availabilities.Add(new SelectListItem() { Text = "Rented", Value = "Rented" });
            availabilities.Add(new SelectListItem() { Text = "Available", Value = "Available" });
            availabilities.Add(new SelectListItem() { Text = "Being Serviced", Value = "Being Serviced" });

            conditions.Add(new SelectListItem() { Text = "Other", Value = "Other" });
            conditions.Add(new SelectListItem() { Text = "Excellent", Value = "Excellent" });
            conditions.Add(new SelectListItem() { Text = "Driveable", Value = "Driveable" });
            conditions.Add(new SelectListItem() { Text = "Needs Service", Value = "Needs Service" });

            ViewBag.Category = types;
            ViewBag.Condition = conditions;
            ViewBag.AvailabilityStatus = availabilities;

            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,TagNumber,Make,Model,Passengers,Category,Condition,AvailabilityStatus")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> types = new List<SelectListItem>();
            List<SelectListItem> conditions = new List<SelectListItem>();
            List<SelectListItem> availabilities = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "SUV", Value = "SUV", Selected = (car.Category == "SUV") });
            types.Add(new SelectListItem() { Text = "Compact", Value = "Compact", Selected = (car.Category == "Compact") });
            types.Add(new SelectListItem() { Text = "Economy", Value = "Economy", Selected = (car.Category == "Economy") });
            types.Add(new SelectListItem() { Text = "Mini Van", Value = "Mini Van", Selected = (car.Category == "Mini Van") });
            types.Add(new SelectListItem() { Text = "Category", Value = "Category", Selected = (car.Category == "Category") });
            types.Add(new SelectListItem() { Text = "Standard", Value = "Standard", Selected = (car.Category == "Standard") });
            types.Add(new SelectListItem() { Text = "Full Size", Value = "Full Size", Selected = (car.Category == "Full Size") });
            types.Add(new SelectListItem() { Text = "Pickup Truck", Value = "Pickup Truck", Selected = (car.Category == "Pickup Truck") });
            types.Add(new SelectListItem() { Text = "Passenger Van", Value = "Passenger Van", Selected = (car.Category == "Passenger Van") });

            availabilities.Add(new SelectListItem() { Text = "Other", Value = "Other", Selected = (car.AvailabilityStatus == "Other") });
            availabilities.Add(new SelectListItem() { Text = "Rented", Value = "Rented", Selected = (car.AvailabilityStatus == "Rented") });
            availabilities.Add(new SelectListItem() { Text = "Unknown", Value = "Available", Selected = (car.AvailabilityStatus == "Unknown") });
            availabilities.Add(new SelectListItem() { Text = "Available", Value = "Available", Selected = (car.AvailabilityStatus == "Available") });
            availabilities.Add(new SelectListItem() { Text = "Being Serviced", Value = "Being Serviced", Selected = (car.AvailabilityStatus == "Being Serviced") });

            conditions.Add(new SelectListItem() { Text = "Good", Value = "Good", Selected = (car.Condition == "Good") });
            conditions.Add(new SelectListItem() { Text = "Other", Value = "Other", Selected = (car.Condition == "Other") });
            conditions.Add(new SelectListItem() { Text = "Excellent", Value = "Excellent", Selected = (car.Condition == "Excellent") });
            conditions.Add(new SelectListItem() { Text = "Driveable", Value = "Driveable", Selected = (car.Condition == "Driveable") });
            conditions.Add(new SelectListItem() { Text = "Needs Service", Value = "Needs Service", Selected = (car.Condition == "Needs Service") });

            ViewBag.Category = types;
            ViewBag.Condition = conditions;
            ViewBag.AvailabilityStatus = availabilities;

            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,TagNumber,Make,Model,Passengers,Category,Condition,AvailabilityStatus")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
