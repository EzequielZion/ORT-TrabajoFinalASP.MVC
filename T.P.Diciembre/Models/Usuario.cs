using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.OleDb;
using T.P.Diciembre.Models;
using System.ComponentModel.DataAnnotations;

namespace T.P.Diciembre.Models
{
    public class Usuario
    {
        public Usuario()
        {
            //lol ni idea por que puse esto pero funciona
        }
        public Usuario(string AuxNombre, string AuxMail, string AuxContraseña)
        {
            Nombre = AuxNombre;
            Mail = AuxMail;
            Contraseña = AuxContraseña;
        }
        public static int IdUsuario { get; set; }
        
        [Required(ErrorMessage = "El nombre ingresado no es válido")]
        public string Nombre { get; set; }
        
        [EmailAddress(ErrorMessage = "El mail ingresado no es válido")]
        [Required(ErrorMessage = "El mail ingresado no es correcto")]
        public string Mail { get; set; }
        
        [Required(ErrorMessage = "La contraseña ingresada no es válida/correcta")]
        public string Contraseña { get; set; }
    }
}



