using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoDAD.Models
{
    public class Tangibilidad
    {
        public int t1 { get; set; }
        public int t2 { get; set; }
        public int t3 { get; set; }
        public int t4 { get; set; }
        public int t5 { get; set; }
        public int t6 { get; set; }
        public int t7 { get; set; }

        public Tangibilidad()
        {

        }
        public List<Tangibilidad> getTangibilidad()
        {
            List<Tangibilidad> tangibilidad = new List<Tangibilidad>();
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dataReader;

            //con.ConnectionString = "Data Source = DESKTOP-RS7QS73; Database = ProyectoDAD; Integrated Security=true;";
            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT [1],[2],[3],[4],[5] FROM(SELECT Tipos, valores FROM[dbo].[Tangibilidad] UNPIVOT (valores for Tipos in ([T1],[T2],[T3],[T4],[T5],[T6],[T7])) as t2) AS X PIVOT (  COUNT(valores) FOR valores in ([1],[2],[3],[4],[5])) as p";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Tangibilidad tang = new Tangibilidad();
                tang.t1 = dataReader.GetInt32(0);
                tang.t2 = dataReader.GetInt32(1);
                tang.t3 = dataReader.GetInt32(2);
                tang.t4 = dataReader.GetInt32(3);
                tang.t5 = dataReader.GetInt32(4);
                //tang.t6 = dataReader.GetInt32(5);
                //tang.t7 = dataReader.GetInt32(6);
                tangibilidad.Add(tang);
            }
            return tangibilidad;
        }
    }
}