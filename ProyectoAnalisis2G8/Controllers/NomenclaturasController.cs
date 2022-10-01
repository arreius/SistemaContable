using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAnalisis2G8.Models;

namespace ProyectoAnalisis2G8.Controllers
{
    public class NomenclaturasController : Controller
    {
        private SistemaContableEntities db = new SistemaContableEntities();

        // GET: Nomenclaturas
        public ActionResult Index()
        {
            return View(db.Nomenclatura.ToList());
        }

        // GET: Nomenclaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomenclatura nomenclatura = db.Nomenclatura.Find(id);
            if (nomenclatura == null)
            {
                return HttpNotFound();
            }
            return View(nomenclatura);
        }

        // GET: Nomenclaturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nomenclaturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuenta,num_cuenta,nombre_cuenta,descripcion,tipo_cuenta,nivel")] Nomenclatura nomenclatura)
        {
            if (ModelState.IsValid)
            {
                db.Nomenclatura.Add(nomenclatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nomenclatura);
        }

        // GET: Nomenclaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomenclatura nomenclatura = db.Nomenclatura.Find(id);
            if (nomenclatura == null)
            {
                return HttpNotFound();
            }
            return View(nomenclatura);
        }

        // POST: Nomenclaturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuenta,num_cuenta,nombre_cuenta,descripcion,tipo_cuenta,nivel")] Nomenclatura nomenclatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomenclatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nomenclatura);
        }

        // GET: Nomenclaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomenclatura nomenclatura = db.Nomenclatura.Find(id);
            if (nomenclatura == null)
            {
                return HttpNotFound();
            }
            return View(nomenclatura);
        }

        // POST: Nomenclaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nomenclatura nomenclatura = db.Nomenclatura.Find(id);
            db.Nomenclatura.Remove(nomenclatura);
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
