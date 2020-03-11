using DairyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DairyMVC.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        DiaryDBEntities instance = new DiaryDBEntities();

        public ActionResult ViewSale()
        {
            return View(instance.tblSales.ToList());
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] tblSale addDetails)
        {
            if (!ModelState.IsValid)
                return View();
            instance.tblSales.Add(addDetails);
            instance.SaveChanges();
            
            return RedirectToAction("ViewSale");


        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            var saleToEdit = (from m in instance.tblSales where m.id == id select m).First();
            return View(saleToEdit);
        }

        // POST: Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(tblSale saleToEdit)
        {
            var orignalRecord = (from m in instance.tblSales where m.id == saleToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(saleToEdit);

            instance.SaveChanges();
            return RedirectToAction("ViewSale");

        }

        // GET: Sale/Delete/5
        public ActionResult Delete(tblSale saleToDelete)
        {
            
            var d = instance.tblSales.Where(x => x.id == saleToDelete.id).FirstOrDefault();
            instance.tblSales.Remove(d);
            instance.SaveChanges();
            

            return View("ViewSale");
        }

        // POST: Sale/Delete/5
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
