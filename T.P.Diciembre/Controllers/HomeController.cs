using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T.P.Diciembre.Models;
using T.P.Diciembre.Models.DataAccess;
using System.IO;

namespace T.P.Diciembre.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Login()
        {
            return View("ViewLogin");
        }

        public ActionResult Registrar()
        {
            return View("ViewRegistro");
        }
        
        public ActionResult GuardarUsuario(Usuario EsteUsuario)
        {
            if(ModelState.IsValid)
            {
                Usuarios.GuardarUsuario(EsteUsuario);
                return View("ViewUsuarioRegistrado");
            }
            else
            {
                return View("ViewRegistro", EsteUsuario);
            }
        }

        public ActionResult ALoguear(Usuario UsuarioALoguear)
        {
            if (ModelState.IsValidField("Mail") && ModelState.IsValidField("Contraseña"))
            {
                Usuario TheUser = Usuarios.EstaoNoEsta(UsuarioALoguear);
                if (TheUser.Nombre != null)
                {
                    ViewBag.Nombre = TheUser.Nombre;
                    ViewBag.ListaAmigos = Amigos.TraerAmigos(Usuario.IdUsuario /*esto solo funciona si en la definición del parámetro ponés "static" REVISAR POR QUÉ*/);
                    return View("ViewUsuarioLogueado");
                }
                else
                {
                    return View("ViewLogin", UsuarioALoguear);
                }
            }
            else
            {
                return View("ViewLogin", UsuarioALoguear);
            }
        }

        public ActionResult CargarAmigo()
        {
            return View("ViewCargarAmigo");
        }

        public ActionResult GuardarAmigo(Amigo EsteAmigo, HttpPostedFileBase FotoASubir) //esto es un método
        {
            if (FotoASubir != null) // si el archivo no es nulo
            {
                if (FotoASubir.ContentLength > 0) // si contiene un largo adecuado
                {
                    //tomo el nombre del archivo y lo guardo en la carpeta Content/Imagenes de MI proyecto
                    string NombreFoto = Path.GetFileName(FotoASubir.FileName);
                    string RutaDeAcceso = Path.Combine(Server.MapPath("~/Content/Imagenes/"), NombreFoto);
                    FotoASubir.SaveAs(RutaDeAcceso);
                    //Guardo el resto de los datos del amigo en la base de Datos
                    EsteAmigo.Foto = NombreFoto;
                }
            }
            Amigos.GuardarAmigo(EsteAmigo);
            ViewBag.ListaAmigos = Amigos.TraerAmigos(Usuario.IdUsuario);
            Usuario User = Usuarios.MandarUsuario(Usuario.IdUsuario);
            ViewBag.Nombre = User.Nombre;
            return View("ViewUsuarioLogueado");
        }

        public ActionResult DeleteFriend(int IdAmigoAEliminar, int IdUsuario)
        {
            bool Funciono = Amigos.EliminarAmigo(IdAmigoAEliminar);
            ViewBag.ListaAmigos = Amigos.TraerAmigos(Usuario.IdUsuario);
            Usuario User = Usuarios.MandarUsuario(Usuario.IdUsuario);
            ViewBag.Nombre = User.Nombre;
            return View("ViewUsuarioLogueado");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}