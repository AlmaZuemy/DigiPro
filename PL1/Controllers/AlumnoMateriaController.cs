using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL1.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        public ActionResult MateriasAsignadas(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            result = BL.AlumnoMateria.MateriasAsignadas(IdAlumno);
            ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);
            alumnoMateria.AlumnoMaterias = result.Objects;
            alumnoMateria.Alumno = ((ML.Alumno)resultalumno.Object);
            return View(alumnoMateria);
        }

        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            result = BL.AlumnoMateria.GetAll();
            alumnomateria.AlumnoMaterias = result.Objects;

            return View(alumnomateria);
        }
        //[HttpPost]
        public ActionResult MateriasSinAsignar(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.MateriasSinAsignar(IdAlumno);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.Alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }

        [HttpPost]
        public ActionResult AgregarMaterias(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            if (alumnoMateria.AlumnoMaterias != null)
            {
                foreach (string IdMateria in alumnoMateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateriaItem = new ML.AlumnoMateria();

                    alumnomateriaItem.Alumno = new ML.Alumno();
                    alumnomateriaItem.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    alumnomateriaItem.Materia = new ML.Materia();
                    alumnomateriaItem.Materia.IdMateria = int.Parse(IdMateria);

                    ML.Result resul = BL.AlumnoMateria.Add(alumnomateriaItem);
                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizado al alumno";
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnoMateria.Alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdAlumnoMateria, int IdAlumno)
        {
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
            alumnomateria.IdAlumnoMateria = IdAlumnoMateria;
            ML.Result result = BL.AlumnoMateria.Delete(alumnomateria);

            ViewBag.MateriasAsignadas = true;
            ViewBag.IdAlumno = IdAlumno;

            if (result.Correct)
            {
                ViewBag.message = "Se ha eliminado exitosamente el registro";
            }
            else
            {
                ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

            }
            return PartialView("Modal");
        }
    }
}
