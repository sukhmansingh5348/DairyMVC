using DairyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DairyMVC.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        DiaryDBEntities instance = new DiaryDBEntities();

        public ActionResult StaffDetails()
        {
            return View(instance.tblStaffs.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] tblStaff addDetails)
        {

            if (!ModelState.IsValid)
                return View();
            instance.tblStaffs.Add(addDetails);
            instance.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("StaffDetails");

        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            var staffToEdit = (from m in instance.tblStaffs where m.id == id select m).First();
            return View(staffToEdit);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(tblStaff staffToEdit)
        {
            var orignalRecord = (from m in instance.tblStaffs where m.id == staffToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(staffToEdit);

            instance.SaveChanges();
            return RedirectToAction("StaffDetails");

        }

        // GET: Staff/Delete/5
        public ActionResult Delete(tblStaff staffToDelete)
        {
            
            var d = instance.tblStaffs.Where(x => x.id == staffToDelete.id).FirstOrDefault();
            instance.tblStaffs.Remove(d);
            instance.SaveChanges();
            return View("StaffDetails");
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
