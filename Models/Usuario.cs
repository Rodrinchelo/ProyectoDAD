using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProyectoDAD.Models
{
    public class Usuario
    {
        public String nombre { get; set; }
        public String sexo { get; set; }
        public int cantidad { get; set; }
        public Usuario()
        {

        }
        public List<Usuario> getUsuario()
        {
            List<Usuario> user = new List<Usuario>();
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dataReader;

            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT Sexo, count(*) as cantidad FROM Alumno GROUP BY sexo";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.sexo = dataReader.GetString(0);
                usuario.cantidad = dataReader.GetInt32(1);
                user.Add(usuario);
            }
            return user;
        }
    }
    
}