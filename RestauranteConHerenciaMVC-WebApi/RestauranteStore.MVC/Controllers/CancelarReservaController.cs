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
    public class CancelarReservaController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public CancelarReservaController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public CancelarReservaController()
        {

        }

        // GET: CancelarReserva
        public ActionResult Index()
        {
            return View(_UnityOfWork.CancelarReservas.GetAll());
        }

        // GET: CancelarReserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancelarReserva cancelarReserva = _UnityOfWork.CancelarReservas.Get(id);
            if (cancelarReserva == null)
            {
                return HttpNotFound();
            }
            return View(cancelarReserva);
        }

        // GET: CancelarReserva/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CancelarReserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CancelarReservaId,Fecha,Hora,NumMesa,PersonaID")] CancelarReserva cancelarReserva)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.CancelarReservas.Add(cancelarReserva);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cancelarReserva);
        }

        // GET: CancelarReserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancelarReserva cancelarReserva = _UnityOfWork.CancelarReservas.Get(id);
            if (cancelarReserva == null)
            {
                return HttpNotFound();
            }
            return View(cancelarReserva);
        }

        // POST: CancelarReserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CancelarReservaId,Fecha,Hora,NumMesa,PersonaID")] CancelarReserva cancelarReserva)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModedified(cancelarReserva);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cancelarReserva);
        }

        // GET: CancelarReserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancelarReserva cancelarReserva = _UnityOfWork.CancelarReservas.Get(id);
            if (cancelarReserva == null)
            {
                return HttpNotFound();
            }
            return View(cancelarReserva);
        }

        // POST: CancelarReserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CancelarReserva cancelarReserva = _UnityOfWork.CancelarReservas.Get(id);
            _UnityOfWork.CancelarReservas.Delete(cancelarReserva);
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
