using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Helpers
{
    public sealed class Singleton
    {

        public static Singleton instance { get; } = new Singleton();

        public bool IsLoggedIn { get; set; } = false;

        private Singleton()
        {

        }
    }
}