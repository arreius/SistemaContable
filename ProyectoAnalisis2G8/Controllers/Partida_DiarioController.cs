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
    public class Partida_DiarioController : Controller
    {
        private SistemaContableEntities db = new SistemaContableEntities();

        // GET: Partida_Diario
        public ActionResult Index()
        {
            return View(db.Partida_Diario.ToList());
        }

        // GET: Partida_Diario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida_Diario partida_Diario = db.Partida_Diario.Find(id);
            ViewBag.detailsPartida = db.Detalle_Partida_Diario.Where(a => a.id_partida == id).ToList();
            if (partida_Diario == null)
            {
                return HttpNotFound();
            }
            return View(partida_Diario);
        }

        // GET: Partida_Diario/Create
        public ActionResult Create()
        {

            ViewBag.num_cuenta = new SelectList(db.Nomenclatura, "num_cuenta", "num_cuenta");
            ViewBag.acList = db.Nomenclatura.ToList();
            return View();
        }

        // POST: Partida_Diario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Partida_Diario partida_Diario)
        {
            Partida_Diario partida_objeto = new Partida_Diario();

            if (ModelState.IsValid)
            {
                partida_objeto.correlativo = partida_Diario.correlativo;
                partida_objeto.num_documento = partida_Diario.num_documento;
                partida_objeto.fecha = partida_Diario.fecha;
                partida_objeto.descripcion = partida_Diario.descripcion;
                db.Partida_Diario.Add(partida_objeto);
                db.SaveChanges();
               
            }

            foreach(var item in partida_Diario.Detalle_Partida_Diario)
            {
                Detalle_Partida_Diario detalleObj=new Detalle_Partida_Diario();
                detalleObj.id_partida = partida_objeto.id_partida;
                detalleObj.id_cuenta  = item.id_cuenta;
                detalleObj.debe=item.debe;
                detalleObj.haber = item.haber;
                db.Detalle_Partida_Diario.Add(detalleObj);
                db.SaveChanges();
               
            }

            return RedirectToAction("Index");
        }

        // GET: Partida_Diario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida_Diario partida_Diario = db.Partida_Diario.Find(id);
            ViewBag.detailsPartida = db.Detalle_Partida_Diario.Where(a => a.id_partida == id).ToList();
            ViewBag.nomenclatura = db.Nomenclatura.ToList();
            if (partida_Diario == null)
            {
                return HttpNotFound();
            }
            return View(partida_Diario);
        }

        // POST: Partida_Diario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Partida_Diario partida_Diario)
        {
            Partida_Diario partida_objeto = new Partida_Diario();
            partida_objeto.id_partida=partida_Diario.id_partida;
            partida_objeto.correlativo = partida_Diario.correlativo;
            partida_objeto.num_documento = partida_Diario.num_documento;
            partida_objeto.fecha = partida_Diario.fecha;
            partida_objeto.descripcion = partida_Diario.descripcion;

            if (ModelState.IsValid)
            {
                db.Entry(partida_objeto).State = EntityState.Modified;
                db.SaveChanges();
                
            }

            List<Detalle_Partida_Diario> detallePD = db.Detalle_Partida_Diario.Where(a => a.id_partida == partida_objeto.id_partida).ToList();

            foreach (var item in detallePD)
            {

                db.Detalle_Partida_Diario.Remove(item);
                db.SaveChanges();
            }

            foreach (var item in partida_Diario.Detalle_Partida_Diario)
            {
                Detalle_Partida_Diario detalleObj = new Detalle_Partida_Diario();
                detalleObj.id_partida = partida_objeto.id_partida;
                detalleObj.id_cuenta = item.id_cuenta;
                detalleObj.debe = item.debe;
                detalleObj.haber = item.haber;
                db.Detalle_Partida_Diario.Add(detalleObj);
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }

        // GET: Partida_Diario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida_Diario partida_Diario = db.Partida_Diario.Find(id);
            if (partida_Diario == null)
            {
                return HttpNotFound();
            }
            return View(partida_Diario);
        }

        // POST: Partida_Diario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partida_Diario partida_Diario = db.Partida_Diario.Find(id);
            List<Detalle_Partida_Diario> detallePD = db.Detalle_Partida_Diario.Where(a => a.id_partida == id).ToList();

            foreach (var item in detallePD)
            {
                
                db.Detalle_Partida_Diario.Remove(item);
                db.SaveChanges();
            }
      
            db.Partida_Diario.Remove(partida_Diario);
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
