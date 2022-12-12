using ProyectoFinal.Helpers;
using ProyectoFinal.Models;
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

            return View(new List<Vacaciones>());
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            if (!Singleton.instance.IsLoggedIn)
            {

                return RedirectToAction("Login", "Usuario");

            }

            return View(_dbContext.Vacaciones.Include(x => x.Empleado).Where(x=>x.EmpleadoId == id).ToList());
        }
    }
}