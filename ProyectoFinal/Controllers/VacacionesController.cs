using ProyectoFinal.Helpers;
using ProyectoFinal.Models;
using ProyectoFinal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class VacacionesController : Controller
    {
        private readonly EmpleadosDbContext _dbContext;
        public VacacionesController()
        {
            _dbContext = new EmpleadosDbContext();
        }

        // GET: Vacaciones
        public ActionResult Index()
        {
            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }

            ViewBag.Empleados = _dbContext.Empleados.Where(x => x.Username != "admin").ToList();

            return View(new List<Vacaciones>());
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }
            ViewBag.Empleados = _dbContext.Empleados.Where(x => x.Username != "admin").ToList();

            return View(_dbContext.Vacaciones.Include(x => x.Empleado).Where(x=>x.EmpleadoId == id).ToList());
        }

        public ActionResult Add() {

            ViewBag.Empleados = _dbContext.Empleados.Where(x => x.Username != "admin").ToList();


            return View();

        }
        [HttpPost]
        public ActionResult Add(SaveVacacionesViewModel saveVacaciones) {

            if (!ModelState.IsValid)
            {
                ViewBag.Empleados = _dbContext.Empleados.Where(x => x.Username != "admin").ToList();

                return View(saveVacaciones);

            }

            _dbContext.Set<Vacaciones>().Add(new Vacaciones() { EmpleadoId = saveVacaciones.EmpleadoId, FechaInicio = saveVacaciones.FechaInicio, FechaFinal = saveVacaciones.FechaFinal });
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}