using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL1.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAll();
            alumno.Alumnos = result.Objects;
            return View(alumno);
            //ServiceReferenceAlumno.ServiceAlumnoClient alumnoclient = new ServiceReferenceAlumno.ServiceAlumnoClient();

            //alumnoclient.GetAll();

            //return View(alumnoclient);
        }
        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Result result = new ML.Result();
            ML.Alumno alumno = new ML.Alumno();
            if (IdAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                result = BL.Alumno.GetById(IdAlumno.Value);
                if (result.Correct)
                {
                    alumno = ((ML.Alumno)result.Object);

                    return View(alumno);
                }
            }
            return View(result);
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            if (alumno.IdAlumno == 0)
            {
                result = BL.Alumno.Add(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "El alumno se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Message = "El alumno no se ha registrado correctamente " + result.ErrorMessage;
                }

            }
            else
            {
                result = BL.Alumno.Update(alumno);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "El alumno se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El alumno no se ha registrado correctamente " + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

    }
}

