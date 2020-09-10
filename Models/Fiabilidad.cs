using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProyectoDAD.Models
{
    public class Fiabilidad
    {
        public int f1 { get; set; }
        public int f2 { get; set; }
        public int f3 { get; set; }
        public int f4 { get; set; }
        public int f5 { get; set; }

        public Fiabilidad()
        {

        }
        public List<Fiabilidad> getFiabilidad()
        {
            List<Fiabilidad> fiab = new List<Fiabilidad>();
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dataReader;

            //con.ConnectionString = "Data Source = DESKTOP-RS7QS73; Database = ProyectoDAD; Integrated Security=true;";
            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT [1],[2],[3],[4],[5] FROM(SELECT Tipos, valores FROM[dbo].[Fiabilidad] UNPIVOT (valores for Tipos in ([F1],[F2],[F3],[F4],[F5])) as t2) AS X PIVOT (  COUNT(valores) FOR valores in ([1],[2],[3],[4],[5])) as p";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Fiabilidad fiabi = new Fiabilidad();
                fiabi.f1 = dataReader.GetInt32(0);
                fiabi.f2 = dataReader.GetInt32(1);
                fiabi.f3 = dataReader.GetInt32(2);
                fiabi.f4 = dataReader.GetInt32(3);
                fiabi.f5 = dataReader.GetInt32(4);
                fiab.Add(fiabi);
            }
            return fiab;
        }
    }
}