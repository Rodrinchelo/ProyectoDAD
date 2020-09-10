using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoDAD.Models
{
    public class Seguridad
    {
        public int s1 { get; set; }
        public int s2 { get; set; }
        public int s3 { get; set; }
        public int s4 { get; set; }
        public int s5 { get; set; }

        public Seguridad()
        {

        }
        public List<Seguridad> getSeguridad()
        {
            List<Seguridad> seguridad = new List<Seguridad>();
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dataReader;

            //con.ConnectionString = "Data Source = DESKTOP-RS7QS73; Database = ProyectoDAD; Integrated Security=true;";
            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT [1],[2],[3],[4],[5] FROM(SELECT Tipos, valores FROM[dbo].[Seguridad] UNPIVOT (valores for Tipos in ([S1],[S2],[S3],[S4])) as t2) AS X PIVOT (  COUNT(valores) FOR valores in ([1],[2],[3],[4],[5])) as p";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Seguridad seg = new Seguridad();
                seg.s1 = dataReader.GetInt32(0);
                seg.s2 = dataReader.GetInt32(1);
                seg.s3 = dataReader.GetInt32(2);
                seg.s4 = dataReader.GetInt32(3);
                seg.s5 = dataReader.GetInt32(4);
                seguridad.Add(seg);
            }
            return seguridad;
        }
    }
}