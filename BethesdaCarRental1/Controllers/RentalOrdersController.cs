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
    public class RentalOrdersController : Controller
    {
        private BethesdaCarRentalEntities db = new BethesdaCarRentalEntities();

        // GET: RentalOrders
        public ActionResult Index()
        {
            var rentalOrders = db.RentalOrders.Include(r => r.Car).Include(r => r.Employee);
            return View(rentalOrders.ToList());
        }

        // GET: RentalOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            if (rentalOrder == null)
            {
                return HttpNotFound();
            }
            return View(rentalOrder);
        }

        // GET: RentalOrders/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Vehicle");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Clerk");

            List<SelectListItem> tanks = new List<SelectListItem>();
            List<SelectListItem> status = new List<SelectListItem>();
            List<SelectListItem> conditions = new List<SelectListItem>();

            conditions.Add(new SelectListItem() { Text = "Other", Value = "Other" });
            conditions.Add(new SelectListItem() { Text = "Excellent", Value = "Excellent" });
            conditions.Add(new SelectListItem() { Text = "Driveable", Value = "Driveable" });
            conditions.Add(new SelectListItem() { Text = "Needs Service", Value = "Needs Service" });

            tanks.Add(new SelectListItem() { Text = "Empty", Value = "Empty" });
            tanks.Add(new SelectListItem() { Text = "1/4 Empty", Value = "1/4 Empty" });
            tanks.Add(new SelectListItem() { Text = "Half", Value = "Half" });
            tanks.Add(new SelectListItem() { Text = "3/4 Full", Value = "3/4 Full" });
            tanks.Add(new SelectListItem() { Text = "Full", Value = "Full" });

            status.Add(new SelectListItem() { Text = "Other", Value = "Other" });
            status.Add(new SelectListItem() { Text = "Ongoing", Value = "Ongoing" });
            status.Add(new SelectListItem() { Text = "Order Reserved", Value = "Order Reserved" });
            status.Add(new SelectListItem() { Text = "Order Completed", Value = "Order Completed" });

            ViewBag.TankLevel = tanks;
            ViewBag.OrderStatus = status;
            ViewBag.CarCondition = conditions;

            return View();
        }

        // POST: RentalOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalOrderID,EmployeeID,DriversLicenseNumber,FirstName,LastName,Address,City,County,State,ZIPCode,CarID,CarCondition,TankLevel,MileageStart,MileageEnd,MileageTotal,StartDate,EndDate,TotalDays,RateApplied,SubTotal,TaxRate,TaxAmount,OrderTotal,PaymentDate,OrderStatus")] RentalOrder rentalOrder)
        {
            if (ModelState.IsValid)
            {
                db.RentalOrders.Add(rentalOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Cars, "CarID", "TagNumber", rentalOrder.CarID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeNumber", rentalOrder.EmployeeID);
            return View(rentalOrder);
        }

        // GET: RentalOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            if (rentalOrder == null)
            {
                return HttpNotFound();
            }

            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Vehicle", rentalOrder.CarID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Clerk", rentalOrder.EmployeeID);

            List<SelectListItem> tanks = new List<SelectListItem>();
            List<SelectListItem> status = new List<SelectListItem>();
            List<SelectListItem> conditions = new List<SelectListItem>();

            conditions.Add(new SelectListItem() { Text = "Other", Value = "Other", Selected = (rentalOrder.CarCondition == "Other") });
            conditions.Add(new SelectListItem() { Text = "Excellent", Value = "Excellent", Selected = (rentalOrder.CarCondition == "Excellent") });
            conditions.Add(new SelectListItem() { Text = "Driveable", Value = "Driveable", Selected = (rentalOrder.CarCondition == "Driveable") });
            conditions.Add(new SelectListItem() { Text = "Needs Service", Value = "Needs Service", Selected = (rentalOrder.CarCondition == "Needs Service") });

            tanks.Add(new SelectListItem() { Text = "Empty", Value = "Empty", Selected = (rentalOrder.TankLevel == "Empty") });
            tanks.Add(new SelectListItem() { Text = "1/4 Empty", Value = "1/4 Empty", Selected = (rentalOrder.TankLevel == "1/4 Empty") });
            tanks.Add(new SelectListItem() { Text = "Half", Value = "Half", Selected = (rentalOrder.TankLevel == "Half") });
            tanks.Add(new SelectListItem() { Text = "3/4 Full", Value = "3/4 Full", Selected = (rentalOrder.TankLevel == "3/4 Full") });
            tanks.Add(new SelectListItem() { Text = "Full", Value = "Full", Selected = (rentalOrder.TankLevel == "Full") });

            status.Add(new SelectListItem() { Text = "Other", Value = "Other", Selected = (rentalOrder.OrderStatus == "Other") });
            status.Add(new SelectListItem() { Text = "Ongoing", Value = "Ongoing", Selected = (rentalOrder.OrderStatus == "Ongoing") });
            status.Add(new SelectListItem() { Text = "Order Reserved", Value = "Order Reserved", Selected = (rentalOrder.OrderStatus == "Order Reserved") });
            status.Add(new SelectListItem() { Text = "Order Completed", Value = "Order Completed", Selected = (rentalOrder.OrderStatus == "Order Completed") });

            ViewBag.TankLevel = tanks;
            ViewBag.OrderStatus = status;
            ViewBag.CarCondition = conditions;

            return View(rentalOrder);
        }

        // POST: RentalOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalOrderID,EmployeeID,DriversLicenseNumber,FirstName,LastName,Address,City,County,State,ZIPCode,CarID,CarCondition,TankLevel,MileageStart,MileageEnd,MileageTotal,StartDate,EndDate,TotalDays,RateApplied,SubTotal,TaxRate,TaxAmount,OrderTotal,PaymentDate,OrderStatus")] RentalOrder rentalOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "TagNumber", rentalOrder.CarID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeNumber", rentalOrder.EmployeeID);
            return View(rentalOrder);
        }

        // GET: RentalOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            if (rentalOrder == null)
            {
                return HttpNotFound();
            }
            return View(rentalOrder);
        }

        // POST: RentalOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            db.RentalOrders.Remove(rentalOrder);
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
