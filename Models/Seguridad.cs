using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoDAD.Models
{
    public class Seguridad
    {
        public string nombre { get; set; }
        public decimal s1 { get; set; }
        public decimal s2 { get; set; }
        public decimal s3 { get; set; }
        public decimal s4 { get; set; }
        public decimal s5 { get; set; }

        public Seguridad()
        {

        }
        public List<Seguridad> getSeguridad()
        {
            List<Seguridad> seguridad = new List<Seguridad>();
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dataReader;

            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT nomPre,CAST(CAST([1] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3,2))as [1],  CAST(CAST([2] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [2],  CAST(CAST([3] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [3],  CAST(CAST([4] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [4],  CAST(CAST([5] AS float) / cast(sum([1] +[2] +[3] +[4] +[5]) as float) as decimal(3, 2))as [5] FROM(SELECT nomDim, nomPre,[valor] FROM[dbo].[Respuesta] A inner join dbo.Pregunta B on A.idPre = B.idPre inner join dbo.Dimension C on c.idDim = b.idDim) as X PIVOT(count(valor) for valor in ([1],[2],[3],[4],[5])) as P where nomDim = 'Seguridad' GROUP BY nomPre,[1],[2],[3],[4],[5]";
            dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Seguridad seg = new Seguridad();
                seg.nombre = dataReader.GetString(0);
                seg.s1 = dataReader.GetDecimal(1);
                seg.s2 = dataReader.GetDecimal(2);
                seg.s3 = dataReader.GetDecimal(3);
                seg.s4 = dataReader.GetDecimal(4);
                seg.s5 = dataReader.GetDecimal(5);
                seguridad.Add(seg);
            }
            return seguridad;
        }
    }
}