using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace T.P.Diciembre.Models.DataAccess
{
    public class Usuarios
    {
        public static Usuario EstaoNoEsta(Usuario UsuarioALoguear) 
        //Verifica que un usuario esté en la BD y lo devuelve si está para ser utilizado en otro lado
        {
            Usuario UnUsuario;
            try
            {
                OleDbConnection Conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|DatabaseDiciembre.mdb");
                Conexion.Open();
                OleDbCommand Consulta = Conexion.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerUsuario";
                OleDbParameter Mail = new OleDbParameter("pMail"/*como se llama el parámetro de la consulta*/, UsuarioALoguear.Mail /*De dónde saca el valor del parámetro*/);
                OleDbParameter Contraseña = new OleDbParameter("pContraseña", UsuarioALoguear.Contraseña);
                Consulta.Parameters.Add(Mail);
                Consulta.Parameters.Add(Contraseña);
                OleDbDataReader drUsuario = Consulta.ExecuteReader();
                UnUsuario = new Usuario();
                while (drUsuario.Read())
                {
                    Usuario.IdUsuario = (int)drUsuario["IdUsuario"];
                    string NombreUsuario = drUsuario["Nombre"].ToString();
                    string MailUsuario = drUsuario["Mail"].ToString();
                    string ContraseñaUsuario = drUsuario["Contraseña"].ToString();
                    UnUsuario = new Usuario(NombreUsuario, MailUsuario, ContraseñaUsuario);
                    return UnUsuario;
                }
               return UnUsuario;
            }
            catch (Exception e)
            {
                UnUsuario = new Usuario();
                //Si hay algun error 
                Console.WriteLine("Hubo un Error");
                return UnUsuario;
            }
        }
        public static void GuardarUsuario(Usuario User)
        {
            try
            {
                OleDbConnection Conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|DatabaseDiciembre.mdb");
                Conexion.Open();
                OleDbCommand Consulta = Conexion.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "AgregarUsuario";
                OleDbParameter Nombre = new OleDbParameter("Nombre", User.Nombre);
                OleDbParameter Mail = new OleDbParameter("Foto", User.Mail);
                OleDbParameter Contraseña = new OleDbParameter("NuevaRutaFoto", User.Contraseña);
                Consulta.Parameters.Add(Nombre);
                Consulta.Parameters.Add(Mail);
                Consulta.Parameters.Add(Contraseña);
                Consulta.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception e)
            {
                //gg jodt
            }
        }
        public static Usuario MandarUsuario(int IdUsuario)
        //Recbie el Id del usuario y envía el Usuario correspondiente
        {
            Usuario UnUsuario;
            try
            {
                OleDbConnection Conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|DatabaseDiciembre.mdb");
                Conexion.Open();
                OleDbCommand Consulta = Conexion.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerUsuario2";
                OleDbParameter IdUser = new OleDbParameter("pIdUsuario"/*como se llama el parámetro de la consulta*/,   IdUsuario /*De dónde saca el valor del parámetro*/);
                Consulta.Parameters.Add(IdUser);
                OleDbDataReader drUsuario = Consulta.ExecuteReader();
                UnUsuario = new Usuario();
                while (drUsuario.Read())
                {
                    string NombreUsuario = drUsuario["Nombre"].ToString();
                    string MailUsuario = drUsuario["Mail"].ToString();
                    string ContraseñaUsuario = drUsuario["Contraseña"].ToString();
                    UnUsuario = new Usuario(NombreUsuario, MailUsuario, ContraseñaUsuario);
                    return UnUsuario;
                }
                return UnUsuario;
            }
            catch (Exception e)
            {
                UnUsuario = new Usuario();
                //Si hay algun error 
                Console.WriteLine("Hubo un Error");
                return UnUsuario;
            }
        }
    }
    }
