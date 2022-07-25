using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        
            [HttpGet]
            public ActionResult MateriasAsignadas(int IdAlumno)
            {
                ML.Result result = new ML.Result();
                ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                result = BL.AlumnoMateria.GetMateriaAsignada(IdAlumno);
                ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);
                alumnoMateria.AlumnoMaterias = result.Objects;
                alumnoMateria.Alumno = ((ML.Alumno)resultalumno.Object);
                return View(alumnoMateria);
            }

           
            [HttpGet]
            public ActionResult MateriasNoAsignadas(int IdAlumno)
            {
                ML.Result result = BL.AlumnoMateria.GetMateriaNoAsiganda(IdAlumno);
                ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

                ML.Result resulAlumno = BL.Alumno.GetById(IdAlumno);

                alumnoMateria.AlumnoMaterias = result.Objects;
                alumnoMateria.Alumno = ((ML.Alumno)resulAlumno.Object);

                return View(alumnoMateria);
            }

            [HttpPost]
            public ActionResult AgregarMaterias(ML.AlumnoMateria alumnoMateria)
            {
                ML.Result result = new ML.Result();
                if (alumnoMateria.ListaAlumnos != null)
                {
                    foreach (int IdMateria in alumnoMateria.ListaAlumnos)
                    {
                        ML.AlumnoMateria alumnoMateria1 = new ML.AlumnoMateria();

                        alumnoMateria1.Alumno = new ML.Alumno();
                        alumnoMateria1.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                        alumnoMateria1.Materia = new ML.Materia();
                        alumnoMateria1.Materia.IdMateria = (IdMateria);

                        ML.Result resul = BL.AlumnoMateria.Add(alumnoMateria1);
                    }
                    result.Correct = true;
                    ViewBag.Message = "Se ha actualizado";
                    ViewBag.ProductosAsignados = true;
                }
                else
                {
                    result.Correct = false;
                }
                return PartialView("modal");
            }

            public ActionResult Delete(int IdAlmunoMateria, int IdAlumno)
            {
                ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                alumnoMateria.IdAlumnoMateria = IdAlmunoMateria;
                ML.Result result = BL.AlumnoMateria.Delete(alumnoMateria);



                if (result.Correct)
                {
                    ViewBag.message = "Se ha eliminado exitosamente el registro";
                }
                else
                {
                    ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

                }
                return PartialView("modal");
            }










    }
    }
