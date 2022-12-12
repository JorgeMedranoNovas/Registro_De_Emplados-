using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Contrasena { get; set; }

        public string Error { get; set; }
    }
}