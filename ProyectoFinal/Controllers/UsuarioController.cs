using ProyectoFinal.Helpers;
using ProyectoFinal.Models;
using ProyectoFinal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly EmpleadosDbContext _dbContext;
        public UsuarioController()
        {
            _dbContext = new EmpleadosDbContext();
        }
        // GET: Usuario
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {

            if (!ModelState.IsValid)
            {

                return View(loginViewModel);

            }

            loginViewModel.Contrasena = PasswordEncryption.ComputeSHA256(loginViewModel.Contrasena);

            var usuario = _dbContext.Empleados.FirstOrDefault(x => x.Username == loginViewModel.Usuario && x.Password == loginViewModel.Contrasena);

            if (usuario != null)
            {

                Singleton.instance.IsLoggedIn = true;

                return RedirectToAction("Index", "Empleados");

            }

            loginViewModel.Error = "Usuario / contrasenia incorrecta.";

            return View(loginViewModel);

        }

        public ActionResult LogOut() {

            Singleton.instance.IsLoggedIn = false;

            return RedirectToAction("Login", "Usuario");

        }


    }
}