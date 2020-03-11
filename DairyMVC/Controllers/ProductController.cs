using DairyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DairyMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DiaryDBEntities instance = new DiaryDBEntities();
        public ActionResult ViewProduct()
        {
            return View(instance.tblProducts.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] tblProduct addDetails)
        {
            if (!ModelState.IsValid)
                return View();
            instance.tblProducts.Add(addDetails);
            instance.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("ViewProduct");

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var productToEdit = (from m in instance.tblProducts where m.id == id select m).First();
            return View(productToEdit);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(tblProduct productToEdit)
        {
            var orignalRecord = (from m in instance.tblProducts where m.id == productToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(productToEdit);

            instance.SaveChanges();
            return RedirectToAction("ViewProduct");

        }

        // GET: Product/Delete/5
        public ActionResult Delete(tblProduct productToDelete)
        {
            var d = instance.tblProducts.Where(x => x.id == productToDelete.id).FirstOrDefault();
            instance.tblProducts.Remove(d);
            instance.SaveChanges();
            return View("ViewProduct");
        }

        // POST: Product/Delete/5
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
