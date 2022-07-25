using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        
            [HttpGet]
            public ActionResult Login()
            {
                ML.Alumno alumno = new ML.Alumno();
                alumno.Email = "Leo@gmail.com";
                alumno.Password = "123";
                return View(alumno);
            }

            [HttpPost]
            public ActionResult Login(string email, string password)
            {
                ML.Result result = new ML.Result();
            result = BL.Alumno.GetByIdEmail(email);
            if (result.Correct)
                {
                    ML.Alumno alumno = (ML.Alumno)result.Object;
                    if (alumno.Email == email && alumno.Password == password)
                    {
                        return RedirectToAction("GetAll", "Alumno");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }




        }
    }

