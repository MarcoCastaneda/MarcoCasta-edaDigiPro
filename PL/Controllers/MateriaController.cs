using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        //
        // GET: /Materia/
        [HttpGet]
        public ActionResult Getall()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Materia());
        }

        [HttpGet]
        public JsonResult Get()
        {
            ML.Result result = BL.Materia.GetAll();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int IdMateria)
        {
            ML.Result result = BL.Materia.GetById(IdMateria);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(ML.Materia materia)
        {
            char[] ValidacionNombreMateria = System.Configuration.ConfigurationManager.AppSettings["ValidacionNombreMateria"].ToCharArray();
            // &<>/
            if (materia.Nombre != null)
            {
                foreach (char caracter in ValidacionNombreMateria)
                {


                    materia.Nombre = materia.Nombre.Replace(caracter.ToString(), "");

                }
                if (materia.Nombre != "")
                {
                    ML.Result result = BL.Materia.Add(materia);
                    return Json(result, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);

                }
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }



        }


        [HttpPost]
        public JsonResult Update(ML.Materia materia)
        {
            ML.Result result = BL.Materia.Update(materia);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete(ML.Materia materia)
        {
            ML.Result result = BL.Materia.Delete(materia);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

}
