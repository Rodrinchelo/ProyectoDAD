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
        public int edad { get; set; }
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

            //con.ConnectionString = "Data Source = DESKTOP-RS7QS73; Database = ProyectoDAD; Integrated Security=true;";
            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT edad, sexo, count(*) as cantidad FROM USUARIO GROUP BY edad, sexo";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.edad = dataReader.GetInt32(0);
                usuario.sexo = dataReader.GetString(1);
                usuario.cantidad = dataReader.GetInt32(2);
                user.Add(usuario);
            }
            return user;
        }
    }
    
}