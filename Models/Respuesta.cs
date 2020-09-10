using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoDAD.Models
{
    public class Respuesta
    {
        public int r1 { get; set; }
        public int r2 { get; set; }
        public int r3 { get; set; }
        public int r4 { get; set; }
        public int r5 { get; set; }

        public Respuesta()
        {

        }
        public List<Respuesta> getRespuesta()
        {
            List<Respuesta> respuesta = new List<Respuesta>();
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dataReader;

            //con.ConnectionString = "Data Source = DESKTOP-RS7QS73; Database = ProyectoDAD; Integrated Security=true;";
            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT [1],[2],[3],[4],[5] FROM(SELECT Tipos, valores FROM[dbo].[CapacidadRespuesta] UNPIVOT (valores for Tipos in ([CR1],[CR2],[CR3],[CR4],[CR5])) as t2) AS X PIVOT (  COUNT(valores) FOR valores in ([1],[2],[3],[4],[5])) as p";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Respuesta resp = new Respuesta();
                resp.r1 = dataReader.GetInt32(0);
                resp.r2 = dataReader.GetInt32(1);
                resp.r3 = dataReader.GetInt32(2);
                resp.r4 = dataReader.GetInt32(3);
                resp.r5 = dataReader.GetInt32(4);
                respuesta.Add(resp);
            }
            return respuesta;
        }
    }
}