using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoDAD.Models
{
    public class Empatía
    {
        public string nombre { get; set; }
        public decimal e1 { get; set; }
        public decimal e2 { get; set; }
        public decimal e3 { get; set; }
        public decimal e4 { get; set; }
        public decimal e5 { get; set; }

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
            com.CommandText = "SELECT nomPre, CAST(CAST([1] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3,2))as [1],  CAST(CAST([2] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [2],  CAST(CAST([3] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [3],  CAST(CAST([4] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [4],  CAST(CAST([5] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [5] FROM(SELECT nomDim, nomPre,[valor] FROM[dbo].[Respuesta] A inner join dbo.Pregunta B on A.idPre = B.idPre inner join dbo.Dimension C on c.idDim = b.idDim) as X PIVOT(count(valor) for valor in ([1],[2],[3],[4],[5])) as P where nomDim = 'Empatia' GROUP BY nomPre,[1],[2],[3],[4],[5]";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Empatía emp = new Empatía();
                emp.nombre = dataReader.GetString(0);
                emp.e1 = dataReader.GetDecimal(1);
                emp.e2 = dataReader.GetDecimal(2);
                emp.e3 = dataReader.GetDecimal(3);
                emp.e4 = dataReader.GetDecimal(4);
                emp.e5 = dataReader.GetDecimal(5);
                empatia.Add(emp);
            }
            return empatia;
        }
    }
}