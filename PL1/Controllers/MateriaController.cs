using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PL1.Controllers
{
    public class MateriaController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia resulmateria = new ML.Materia();
            resulmateria.Materias = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9959/");
                var responseTask = client.GetAsync("api/Materia/GetAll");
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemlist = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString()); ;
                        resulmateria.Materias.Add(resultItemlist);
                    }
                }
            }
            return View(resulmateria);
        }

        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (IdMateria == null)
            {
                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();
                ML.Materia resulmateria = new ML.Materia();
                resulmateria.Materias = new List<object>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9959/");
                    var responseTask = client.GetAsync("api/Materia/GetById/" + IdMateria);
                    responseTask.Wait();

                    var resul = responseTask.Result;

                    if (resul.IsSuccessStatusCode)
                    {
                        var readtask = resul.Content.ReadAsAsync<ML.Result>();
                        readtask.Wait();

                        ML.Materia resulitemlist = new ML.Materia();
                        resulitemlist = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readtask.Result.Object.ToString());
                        result.Object = resulitemlist;

                        materia = ((ML.Materia)result.Object);
                    }
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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9959/");

                    var postTask = client.PostAsJsonAsync<ML.Materia>("/api/Materia/Add", materia);
                    postTask.Wait();

                    var resultA = postTask.Result;

                    if (resultA.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "La materia se ha registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "La materia no se ha registrado correctamente " + result.ErrorMessage;
                    }
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9959/");

                    var postTask = client.PostAsJsonAsync<ML.Materia>("api/Materia/Update", materia);
                    postTask.Wait();

                    var resultA = postTask.Result;

                    if (resultA.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "La materia se ha actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "La materia no se ha actualizado correctamente " + result.ErrorMessage;
                    }
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9959/");

                var postTask = client.GetAsync("api/Materia/Delete/" + IdMateria);
                postTask.Wait();

                var resultA = postTask.Result;

                if (resultA.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "La materia se ha eliminado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "La materia no se ha eliminado correctamente " + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }
    }
}

