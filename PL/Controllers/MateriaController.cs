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
       
            public ActionResult GetAll()
            {
                ML.Result result = BL.Materia.GetAll();
                ML.Materia materia = new ML.Materia();

                if (result.Correct)
                {
                    materia.Materias = result.Objects;
                }


                return View(materia);
            }


            [HttpGet]
            public ActionResult Form(int? IdProducto)
            {

                ML.Materia materia = new ML.Materia();
                if (IdProducto == null)
                {
                    return View(materia);
                }
                else
                {
                    ML.Result result = new ML.Result();

                    if (result.Correct)
                    {

                    }

                }
                return View(materia);
            }


            [HttpPost]
            public ActionResult Form(ML.Materia materia)
            {



                ML.Result result = new ML.Result();
               
                if (materia.IdMateria == 0)
                {
                    result = BL.Materia.Add(materia);


                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "El alumno se ha agregado";
                    }
                    else
                    {
                        ViewBag.Mensaje = "El alumno NO se ha agregado";
                    }
                }
                return PartialView("Modal");

            }
         
        }
    }