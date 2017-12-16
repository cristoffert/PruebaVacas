using AnimalesVaca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalesVaca.Controllers
{
    public class HomeController : Controller
    {
        VACAEntities cnx;
        public HomeController()
        {
            cnx = new VACAEntities();
        }
        public ActionResult Formulario()
        {
            return View();
        }
        public ActionResult Guardar(string nombre, string sexo, string raza, string edad, string tipo, string rebaño)
        {

            AnimalesVaca.Models.BDVACA vacas = new AnimalesVaca.Models.BDVACA()
            {
                Nombre = nombre,
                Sexo = sexo,
                Raza = raza,
                Edad = edad,
                Tipo = tipo,
                Rebaño = rebaño
            };

            cnx.BDVACA.Add(vacas);
            cnx.SaveChanges();

            return View("Listado", ListadoVacas());
        }
        public ActionResult Listado()
        {

            return View("Listado", ListadoVacas());
        }
        public ActionResult Ficha( string nombre)
        {
            BDVACA vaca = (BDVACA)cnx.BDVACA.Where(x => x.Nombre.Equals(nombre)).First();

            return View("Ficha", vaca );
        }



        private List<AnimalesVaca.Models.BDVACA> ListadoVacas()
        {

            cnx.Database.Connection.Open();
            List<AnimalesVaca.Models.BDVACA> vacas = cnx.BDVACA.ToList();

            cnx.Database.Connection.Close();

            return vacas;
        }
    }
}