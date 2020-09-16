using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProyectoDAD.Models
{
    public class Fiabilidad
    {
        public string nombre { get; set; }
        public decimal f1 { get; set; }
        public decimal f2 { get; set; }
        public decimal f3 { get; set; }
        public decimal f4 { get; set; }
        public decimal f5 { get; set; }

        public Fiabilidad()
        {

        }
        public List<Fiabilidad> getFiabilidad()
        {
            List<Fiabilidad> fiab = new List<Fiabilidad>();
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dataReader;

            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT nomPre,CAST(CAST([1] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3,2))as [1],  CAST(CAST([2] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [2],  CAST(CAST([3] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [3],  CAST(CAST([4] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [4],  CAST(CAST([5] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [5] FROM(SELECT nomDim, nomPre,[valor] FROM[dbo].[Respuesta] A inner join dbo.Pregunta B on A.idPre = B.idPre inner join dbo.Dimension C on c.idDim = b.idDim) as X PIVOT(count(valor) for valor in ([1],[2],[3],[4],[5])) as P where nomDim = 'Fiabilidad' GROUP BY nomPre,[1],[2],[3],[4],[5]";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Fiabilidad fiabi = new Fiabilidad();
                fiabi.nombre = dataReader.GetString(0);
                fiabi.f1 = dataReader.GetDecimal(1);
                fiabi.f2 = dataReader.GetDecimal(2);
                fiabi.f3 = dataReader.GetDecimal(3);
                fiabi.f4 = dataReader.GetDecimal(4);
                fiabi.f5 = dataReader.GetDecimal(5);
                fiab.Add(fiabi);
            }
            return fiab;
        }
    }
}