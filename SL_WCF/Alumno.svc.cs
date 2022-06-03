using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Alumno : IAlumno
    {
        public SL_WCF.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);
            SL_WCF.Result resultservice = new SL_WCF.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }

        public SL_WCF.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Update(alumno);
            SL_WCF.Result resultservice = new SL_WCF.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }

        public SL_WCF.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Delete(alumno);
            SL_WCF.Result resultservice = new SL_WCF.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }

        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            SL_WCF.Result resultservice = new SL_WCF.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }

        public SL_WCF.Result GetById(int IdAlumno)
        {
            ML.Result result = BL.Alumno.GetById(IdAlumno);
            SL_WCF.Result resultservice = new SL_WCF.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }
    }
}
