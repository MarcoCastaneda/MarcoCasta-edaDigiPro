using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
       
        // GET: /Alumno/
        [HttpGet]
        public ActionResult Getall()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Alumno());
        }

        [HttpGet]
        public JsonResult Get()
        {
            ML.Result result = BL.Alumno.GetAll();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int IdAlumno)
        {
            ML.Result result = BL.Alumno.GetById(IdAlumno);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Update(alumno);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Delete(alumno);

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
    public ActionResult GetAll1()
    {
        ML.Result result = BL.Alumno.GetAll();
        ML.Alumno alumno = new ML.Alumno();

        if (result.Correct)
        {
            alumno.Alumnos = result.Objects;
        }


        return View(alumno);
    }

    //[HttpGet]
    //public ActionResult Form(int? IdAlumno)
    //{

    //    ML.Alumno alumno = new ML.Alumno();
    //    if (IdAlumno == null)
    //    {
    //        return View(alumno);
    //    }
    //    else
    //    {
    //        ML.Result result = new ML.Result();

    //        if (result.Correct)
    //        {

    //        }

    //    }
    //    return View(alumno);
    //}


    //[HttpPost]
    //public ActionResult Form(ML.Alumno alumno)
    //{

    //    ML.Result result = new ML.Result();
    //    if (alumno.IdAlumno == 0)
    //    {
    //        result = BL.Alumno.Add(alumno);


    //        if (result.Correct)
    //        {
    //            ViewBag.Mensaje = "El alumno se ha agregado";
    //        }
    //        else
    //        {
    //            ViewBag.Mensaje = "El alumno NO se ha agregado";
    //        }
    //    }
    //    else
    //    {
    //        result = BL.Alumno.Update(alumno);
    //        if (result.Correct)
    //        {
    //            ViewBag.Mensaje = "El alumno se ha actualizado";
    //        }
    //        else
    //        {

    //            ViewBag.Mensaje = "El alumno NO se actualizo";
    //        }
    //    }
    //    return PartialView("modal");
    //}
    //public ActionResult Delete(int IdAlumno)
    //{
    //    ML.Alumno alumno = new ML.Alumno();
    //    alumno.IdAlumno = IdAlumno;
    //    ML.Result result = BL.Alumno.Delete(alumno);



    //    if (result.Correct)
    //    {
    //        ViewBag.message = "Se ha eliminado exitosamente el registro";
    //    }
    //    else
    //    {
    //        ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

    //    }
    //    return PartialView("modal");
    //}


}

}