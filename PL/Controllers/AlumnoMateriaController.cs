using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        //public ActionResult GetAll()
        //{
        //    ML.Result result = BL.Materia.GetAll();
        //    ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

        //    if (result.Correct)
        //    {
        //        alumnoMateria.AlumnoMaterias = result.Objects;
        //    }


        //    return View(alumnoMateria);
        //}


        //[HttpGet]
        //public ActionResult MateriasAsignadas(int IdAlumno)
        //{
        //    ML.Result result = new ML.Result();
        //    ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
        //    result = BL.AlumnoMateria.GetMateriaAsignada(IdAlumno);
        //    ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);
        //    alumnoMateria.AlumnoMaterias = result.Objects;
        //    alumnoMateria.Alumno = ((ML.Alumno)resultalumno.Object);
        //    return View(alumnoMateria);
        //}


        //[HttpGet]
        //public ActionResult MateriasNoAsignadas(int IdAlumno)
        //{
        //    ML.Result result = BL.AlumnoMateria.GetMateriaNoAsiganda(IdAlumno);
        //    ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

        //    ML.Result resulAlumno = BL.Alumno.GetById(IdAlumno);

        //    alumnoMateria.AlumnoMaterias = result.Objects;
        //    alumnoMateria.Alumno = ((ML.Alumno)resulAlumno.Object);

        //    return View(alumnoMateria);
        //}

        //[HttpPost]
        //public ActionResult AgregarMaterias(ML.AlumnoMateria alumnoMateria)
        //{
        //    ML.Result result = new ML.Result();
        //    if (alumnoMateria.ListaAlumnos != null)
        //    {
        //        foreach (int IdMateria in alumnoMateria.ListaAlumnos)
        //        {
        //            ML.AlumnoMateria alumnoMateria1 = new ML.AlumnoMateria();

        //            alumnoMateria1.Alumno = new ML.Alumno();
        //            alumnoMateria1.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

        //            alumnoMateria1.Materia = new ML.Materia();
        //            alumnoMateria1.Materia.IdMateria = (IdMateria);

        //            ML.Result resul = BL.AlumnoMateria.Add(alumnoMateria1);
        //        }
        //        result.Correct = true;
        //        ViewBag.Message = "Se ha actualizado";
        //        ViewBag.ProductosAsignados = true;
        //    }
        //    else
        //    {
        //        result.Correct = false;
        //    }
        //    return PartialView("modal");
        //}



        //public ActionResult Delete(int IdAlmunoMateria, int IdAlumno)
        //{
        //    ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
        //    alumnoMateria.IdAlumnoMateria = IdAlmunoMateria;
        //    ML.Result result = BL.AlumnoMateria.Delete(alumnoMateria);



        //    if (result.Correct)
        //    {
        //        ViewBag.message = "Se ha eliminado exitosamente el registro";
        //    }
        //    else
        //    {
        //        ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

        //    }
        //    return Json(String.Format("'Success':'false','Error':'Ha habido un error al insertar el registro.'"));
        //}

        public ActionResult GetAllAlumno()
        {
            return View();
        }
        public ActionResult AlumnoMateria()
        {
            return View();
        }




        public JsonResult GetAll()
        {
            var result = BL.Alumno.GetAll();
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyId(ML.Alumno alumno)
        {
            var result = BL.AlumnoMateria.GetMateriaAsignada(alumno);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMateriasNoAsignadas(int IdAlumno)
        {
            var result = BL.AlumnoMateria.GetMateriaNoAsiganda(IdAlumno);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(ML.AlumnoMateria alumnoMateria)
        {
            var result = BL.AlumnoMateria.Add(alumnoMateria);
            return Json(result.Correct, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdAlumnoMateria)
        {
            var result = BL.AlumnoMateria.Delete(IdAlumnoMateria);
            return Json(result.Correct, JsonRequestBehavior.AllowGet);
        }
    }

}

