using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ProyectoFinal.Helpers
{
    public static class PasswordEncryption
    {
        public static string ComputeSHA256(string password) {

            using (SHA256 SHA = SHA256.Create())
            {
                byte[] bytes = SHA.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                foreach (byte bt in bytes) {

                    builder.Append(bt.ToString("x2"));
                
                }

                return builder.ToString();
            }

        }
    }
}