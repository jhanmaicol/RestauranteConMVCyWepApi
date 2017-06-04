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
    public class AlmacenController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public AlmacenController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public AlmacenController()
        {

        }

        // GET: Almacen
        public ActionResult Index()
        {
            return View(_UnityOfWork.Almacenes.GetAll());
        }

        // GET: Almacen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Almacen almacen = db.Almacenes.Find(id);
            Almacen almacen = _UnityOfWork.Almacenes.Get(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // GET: Almacen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Almacen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlmacenId,Inventario,EstadoAlm")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                //db.Almacene.Add(almacen);
                _UnityOfWork.Almacenes.Add(almacen);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(almacen);
        }

        // GET: Almacen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Almacen almacen = db.Almacenes.Find(id);
            Almacen almacen = _UnityOfWork.Almacenes.Get(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // POST: Almacen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlmacenId,Inventario,EstadoAlm")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(almacen).State = EntityState.Modified;
                _UnityOfWork.StateModedified(almacen);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(almacen);
        }

        // GET: Almacen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Almacen almacen = db.Almacenes.Find(id);
            Almacen almacen = _UnityOfWork.Almacenes.Get(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // POST: Almacen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Almacen almacen = db.Almacenes.Find(id);
            Almacen almacen = _UnityOfWork.Almacenes.Get(id);

            //db.Almacene.Remove(almacen);
            _UnityOfWork.Almacenes.Delete(almacen);

            //db.SaveChanges();
            _UnityOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
