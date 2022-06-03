using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceAlumno" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceAlumno
    {
        [OperationContract]
        SL_WCF1.Result Add(ML.Alumno alumno);
        [OperationContract]
        SL_WCF1.Result Update(ML.Alumno alumno);
        [OperationContract]
        SL_WCF1.Result Delete(ML.Alumno alumno);
        [OperationContract]
        SL_WCF1.Result GetAll();
        [OperationContract]
        SL_WCF1.Result GetById(int IdAlumno);
    }
}
