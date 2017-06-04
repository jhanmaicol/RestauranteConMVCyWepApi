using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestauranteStore.Entities.Entities;
using RestauranteStore.Persistence;
using RestauranteStore.Entities.IRepositories;

namespace RestauranteStore.MVC.Controllers
{
    public class CartasController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public CartasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public CartasController()
        {

        }


        // GET: Cartas
        public ActionResult Index()
        {
           // var cartas = db.Cartas.Include(c => c.EspecialidadDia);
            return View(_UnityOfWork.Cartas.GetAll());
        }

        // GET: Cartas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carta carta = _UnityOfWork.Cartas.Get(id);
            if (carta == null)
            {
                return HttpNotFound();
            }
            return View(carta);
        }

        // GET: Cartas/Create
        public ActionResult Create()
        {
            ViewBag.EspecialidadDiaId = new SelectList(db.EspecialidadDias, "EspecialidadDiaId", "EspecialidadDiaId");
            return View();
        }

        // POST: Cartas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartaId,Bebidas,Menu,Postres,EspecialidadDiaId")] Carta carta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Cartas.Add(carta);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecialidadDiaId = new SelectList(db.EspecialidadDias, "EspecialidadDiaId", "EspecialidadDiaId", carta.EspecialidadDiaId);
            return View(carta);
        }

        // GET: Cartas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carta carta = _UnityOfWork.Cartas.Get(id);
            if (carta == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadDiaId = new SelectList(db.EspecialidadDias, "EspecialidadDiaId", "EspecialidadDiaId", carta.EspecialidadDiaId);
            return View(carta);
        }

        // POST: Cartas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartaId,Bebidas,Menu,Postres,EspecialidadDiaId")] Carta carta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadDiaId = new SelectList(db.EspecialidadDias, "EspecialidadDiaId", "EspecialidadDiaId", carta.EspecialidadDiaId);
            return View(carta);
        }

        // GET: Cartas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carta carta = db.Cartas.Find(id);
            if (carta == null)
            {
                return HttpNotFound();
            }
            return View(carta);
        }

        // POST: Cartas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carta carta = db.Cartas.Find(id);
            db.Cartas.Remove(carta);
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
