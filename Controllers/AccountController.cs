using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoDAD.Models;
using System.Data.SqlClient;

namespace ProyectoDAD.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public void connectionString()
        {
            //con.ConnectionString = "Data Source = DESKTOP-RS7QS73; Database = ProyectoDAD; Integrated Security=true;";
            con.ConnectionString = "Server=tcp:proyectodad.database.windows.net,1433;Initial Catalog=DADProyecto;Persist Security Info=False;User ID=proyectodad;Password=DADProyecto123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection= con;
            com.CommandText = "SELECT * FROM LOGIN WHERE username='"+acc.Name+"' and password='"+acc.Password+"'";
            dr = com.ExecuteReader();
            Usuario usuarioModel = new Usuario();
            var usuarioLista = usuarioModel.getUsuario();
            if (dr.Read())
            {
                con.Close();
                return View("Usuario", usuarioLista);
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Fiabilidad()
        {
            Fiabilidad fiaModel = new Fiabilidad();
            var fiabilidadLista = fiaModel.getFiabilidad();
            return View(fiabilidadLista);
        }
        public ActionResult Seguridad()
        {
            Seguridad segModel = new Seguridad();
            var segLista = segModel.getSeguridad();
            return View(segLista);
        }
        public ActionResult Empatia()
        {
            Empatía empModel = new Empatía();
            var empLista = empModel.getEmpatia();
            return View(empLista);
        }
        public ActionResult Respuesta()
        {
            Respuesta resModel = new Respuesta();
            var resLista = resModel.getRespuesta();
            return View(resLista);
        }
        public ActionResult Tangibilidad()
        {
            Tangibilidad tanModel = new Tangibilidad();
            var tanLista = tanModel.getTangibilidad();
            return View(tanLista);
        }
    }
}