using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using ProyectoAnalisis2G8.Models;

namespace ProyectoAnalisis2G8.Controllers
{
    public class Detalle_Partida_DiarioController : Controller
    {
        private SistemaContableEntities db = new SistemaContableEntities();

        // GET: Detalle_Partida_Diario
        public ActionResult Index()
        {
            var detalle_Partida_Diario = db.Detalle_Partida_Diario.Include(d => d.Nomenclatura).Include(d => d.Partida_Diario);
            return View(detalle_Partida_Diario.ToList());
        }

        // GET: Detalle_Partida_Diario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Partida_Diario detalle_Partida_Diario = db.Detalle_Partida_Diario.Find(id);
            if (detalle_Partida_Diario == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Partida_Diario);
        }

        // GET: Detalle_Partida_Diario/Create
        public ActionResult Create()
        {
            ViewBag.id_cuenta = new SelectList(db.Nomenclatura, "id_cuenta", "num_cuenta");
            ViewBag.id_partida = new SelectList(db.Partida_Diario, "id_partida", "correlativo");
            return View();
        }

        // POST: Detalle_Partida_Diario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuenta,id_partida,debe,haber")] Detalle_Partida_Diario detalle_Partida_Diario)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Partida_Diario.Add(detalle_Partida_Diario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cuenta = new SelectList(db.Nomenclatura, "id_cuenta", "num_cuenta", detalle_Partida_Diario.id_cuenta);
            ViewBag.id_partida = new SelectList(db.Partida_Diario, "id_partida", "correlativo", detalle_Partida_Diario.id_partida);
            return View(detalle_Partida_Diario);
        }

        // GET: Detalle_Partida_Diario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Partida_Diario detalle_Partida_Diario = db.Detalle_Partida_Diario.Find(id);
            if (detalle_Partida_Diario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cuenta = new SelectList(db.Nomenclatura, "id_cuenta", "num_cuenta", detalle_Partida_Diario.id_cuenta);
            ViewBag.id_partida = new SelectList(db.Partida_Diario, "id_partida", "correlativo", detalle_Partida_Diario.id_partida);
            return View(detalle_Partida_Diario);
        }

        // POST: Detalle_Partida_Diario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuenta,id_partida,debe,haber")] Detalle_Partida_Diario detalle_Partida_Diario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Partida_Diario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cuenta = new SelectList(db.Nomenclatura, "id_cuenta", "num_cuenta", detalle_Partida_Diario.id_cuenta);
            ViewBag.id_partida = new SelectList(db.Partida_Diario, "id_partida", "correlativo", detalle_Partida_Diario.id_partida);
            return View(detalle_Partida_Diario);
        }

        // GET: Detalle_Partida_Diario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Partida_Diario detalle_Partida_Diario = db.Detalle_Partida_Diario.Find(id);
            if (detalle_Partida_Diario == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Partida_Diario);
        }

        // POST: Detalle_Partida_Diario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Partida_Diario detalle_Partida_Diario = db.Detalle_Partida_Diario.Find(id);
            

            db.Detalle_Partida_Diario.Remove(detalle_Partida_Diario);
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
