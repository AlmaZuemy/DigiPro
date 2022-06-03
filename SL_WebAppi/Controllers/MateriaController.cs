using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;


namespace SL_WebAppi.Controllers
{
    public class MateriaController : ApiController
    {
        [HttpGet]
        [Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();

            if (!result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        [HttpPost]
        [Route("api/Materia/Add")]
        public IHttpActionResult Post([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Materia/GetById/{IdMateria}")]
        public IHttpActionResult GetById(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            var result = BL.Materia.GetById(IdMateria);

            if (result.Correct)
            {
                return Ok (result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Materia/Update")]
        public IHttpActionResult Update([FromBody] ML.Materia materia)
        {
            var result = BL.Materia.Update(materia);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Materia/Delete/{IdMateria}")]
        public IHttpActionResult Delete(int IdMateria)
        {
            ML.Result result = BL.Materia.Delete(IdMateria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
