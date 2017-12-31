using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace T.P.Diciembre.Models.DataAccess
{
    public class Amigos
    {
        public static void GuardarAmigo(Amigo Friend)
        {
            try
            {
                OleDbConnection Conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|DatabaseDiciembre.mdb");
                Conexion.Open();
                OleDbCommand Consulta = Conexion.CreateCommand();
                Consulta.CommandType = CommandType.StoredProcedure;
                Consulta.CommandText = "AgregarAmigo";
                OleDbParameter Nombre = new OleDbParameter("Nombre", Friend.Nombre);
                OleDbParameter Foto = new OleDbParameter("Foto", Friend.Foto);
                OleDbParameter Descripcion = new OleDbParameter("NuevaRutaFoto", Friend.Descripcion);
                OleDbParameter Pais = new OleDbParameter("Pais", Friend.Pais);
                OleDbParameter IdUsuario = new OleDbParameter("IdUsuario", Usuario.IdUsuario);
                Consulta.Parameters.Add(Nombre);
                Consulta.Parameters.Add(Foto);
                Consulta.Parameters.Add(Descripcion);
                Consulta.Parameters.Add(Pais);
                Consulta.Parameters.Add(IdUsuario);
                Consulta.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception e)
            {
                //gg jodt
            }
        }

        static List<Amigo> ListaAmigos;

        public static List<Amigo> TraerAmigos(int IdUsuarioLogueado)
        {
            ListaAmigos = new List<Amigo>();
            try
            {
                OleDbConnection Conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|DatabaseDiciembre.mdb");
                Conexion.Open();
                OleDbCommand Consulta = Conexion.CreateCommand();
                Consulta.CommandType = CommandType.StoredProcedure;
                Consulta.CommandText = "TraerAmigos";
                OleDbParameter IdUser = new OleDbParameter("pIdUsuario", IdUsuarioLogueado);
                Consulta.Parameters.Add(IdUser);
                OleDbDataReader DataReader = Consulta.ExecuteReader();
                while (DataReader.Read())
                {
                    int IdAmigo = (int)DataReader["IdAmigo"];
                    string Nombre = DataReader["Nombre"].ToString();
                    string Foto = DataReader["Foto"].ToString();
                    string Descripcion = DataReader["Descripcion"].ToString();
                    string Pais = DataReader["Pais"].ToString();
                    int IdUsuario = (int)DataReader["IdUsuario"];
                    Amigo UnAmigo = new Amigo(IdAmigo, Nombre, Foto, Descripcion, Pais, IdUsuario);
                    ListaAmigos.Add(UnAmigo);
                }
                return ListaAmigos;
            }
            catch (Exception e)
            {
                //Si hay algun error 
                Console.WriteLine("Hubo un Error");
                return ListaAmigos;
            }
        }
        public static bool EliminarAmigo(int IdAmigoAEliminar)
        {
            try
            {
                OleDbConnection Conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|DatabaseDiciembre.mdb");
                Conexion.Open();
                OleDbCommand Consulta = Conexion.CreateCommand();
                Consulta.CommandType = CommandType.StoredProcedure;
                Consulta.CommandText = "EliminarAmigo";
                OleDbParameter IdUsuario = new OleDbParameter("pIdAmigo", IdAmigoAEliminar);
                Consulta.Parameters.Add(IdUsuario);
                Consulta.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
