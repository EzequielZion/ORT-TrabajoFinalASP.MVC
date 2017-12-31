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
    public class Amigo
    {
        public Amigo()
        {
        //
        }
        public Amigo(int AuxIdAmigo, string AuxNombre, string AuxFoto, string AuxDescripcion, string AuxPais, int AuxIdUsuario) //esto es un constructor
        {
            IdAmigo = AuxIdAmigo;
            Nombre = AuxNombre;
            Foto = AuxFoto;
            Descripcion = AuxDescripcion;
            Pais = AuxPais;
            IdUsuario = AuxIdUsuario;
        }
        public int IdAmigo { get; set; }

        [Required(ErrorMessage = "El nombre ingresado no es válido")]
        public string Nombre { get; set; }

        public string Foto { get; set; }

        [Required(ErrorMessage = "La descripción ingresada no es válida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El país ingresado no es válido")]
        public string Pais { get; set; }

        public int IdUsuario { get; set; }
    }
}