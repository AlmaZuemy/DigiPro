using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceAlumno" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceAlumno.svc o ServiceAlumno.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceAlumno : IServiceAlumno
    {
        public SL_WCF1.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);
            SL_WCF1.Result resultservice = new SL_WCF1.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }

        public SL_WCF1.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Update(alumno);
            SL_WCF1.Result resultservice = new SL_WCF1.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }

        public SL_WCF1.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Delete(alumno);
            SL_WCF1.Result resultservice = new SL_WCF1.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }

        public SL_WCF1.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            SL_WCF1.Result resultservice = new SL_WCF1.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }

        public SL_WCF1.Result GetById(int IdAlumno)
        {
            ML.Result result = BL.Alumno.GetById(IdAlumno);
            SL_WCF1.Result resultservice = new SL_WCF1.Result();
            resultservice.Correct = result.Correct;
            resultservice.ErrorMessage = result.ErrorMessage;
            resultservice.Objetc = result.Object;
            resultservice.Objects = result.Objects;
            resultservice.Ex = result.Ex;
            return resultservice;
        }
    }
}
