using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoDAD.Models
{
    public class Tangibilidad
    {
        public string nombre { get; set; }
        public decimal t1 { get; set; }
        public decimal t2 { get; set; }
        public decimal t3 { get; set; }
        public decimal t4 { get; set; }
        public decimal t5 { get; set; }

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
            com.CommandText = "SELECT nomPre,CAST(CAST([1] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3,2))as [1],  CAST(CAST([2] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [2],  CAST(CAST([3] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [3],  CAST(CAST([4] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [4],  CAST(CAST([5] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [5] FROM(SELECT nomDim, nomPre,[valor] FROM[dbo].[Respuesta] A inner join dbo.Pregunta B on A.idPre = B.idPre inner join dbo.Dimension C on c.idDim = b.idDim) as X PIVOT(count(valor) for valor in ([1],[2],[3],[4],[5])) as P where nomDim = 'Tangibilidad' GROUP BY nomPre,[1],[2],[3],[4],[5]";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Tangibilidad tang = new Tangibilidad();
                tang.nombre = dataReader.GetString(0);
                tang.t1 = dataReader.GetDecimal(1);
                tang.t2 = dataReader.GetDecimal(2);
                tang.t3 = dataReader.GetDecimal(3);
                tang.t4 = dataReader.GetDecimal(4);
                tang.t5 = dataReader.GetDecimal(5);
                tangibilidad.Add(tang);
            }
            return tangibilidad;
        }
    }
}