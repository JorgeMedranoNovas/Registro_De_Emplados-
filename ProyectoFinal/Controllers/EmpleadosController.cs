using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Helpers;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly EmpleadosDbContext db = new EmpleadosDbContext();

        // GET: Empleados
        public ActionResult Index()
        {


            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }

            var empleados = db.Empleados.Where(e => e.Username != "admin").ToList();
            ViewBag.SumAllSalary = empleados.Sum(e => e.Sueldo);

            return View(empleados);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {

            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }

            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,Nombre,Apellido,Telefono,Direccion,FechaNacimiento,Sueldo,Username,Password")] Empleados empleados)
        {


            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }

            if (ModelState.IsValid)
            {
                empleados.Password = PasswordEncryption.ComputeSHA256(empleados.Password);

                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleado,nombre,apellido,telefono,direccion,fechaNacimiento,sueldo")] Empleados empleados)
        {
            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {


            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {


            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }

            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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
