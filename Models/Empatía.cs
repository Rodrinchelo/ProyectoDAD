using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoDAD.Models
{
    public class Empatía
    {
        public int e1 { get; set; }
        public int e2 { get; set; }
        public int e3 { get; set; }
        public int e4 { get; set; }
        public int e5 { get; set; }

        public Empatía()
        {

        }
        public List<Empatía> getEmpatia()
        {
            List<Empatía> empatia = new List<Empatía>();
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dataReader;

            //con.ConnectionString = "Data Source = DESKTOP-RS7QS73; Database = ProyectoDAD; Integrated Security=true;";
            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT [1],[2],[3],[4],[5] FROM(SELECT Tipos, valores FROM[dbo].[Empatia] UNPIVOT (valores for Tipos in ([E1],[E2],[E3],[E4],[E5])) as t2) AS X PIVOT (  COUNT(valores) FOR valores in ([1],[2],[3],[4],[5])) as p";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Empatía emp = new Empatía();
                emp.e1 = dataReader.GetInt32(0);
                emp.e2 = dataReader.GetInt32(1);
                emp.e3 = dataReader.GetInt32(2);
                emp.e4 = dataReader.GetInt32(3);
                emp.e5 = dataReader.GetInt32(4);
                empatia.Add(emp);
            }
            return empatia;
        }
    }
}