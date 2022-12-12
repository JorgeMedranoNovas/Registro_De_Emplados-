using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models.ViewModel
{
    public class LoginViewModel
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public string Error { get; set; }
    }
}