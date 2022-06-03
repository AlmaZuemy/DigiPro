using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAlumno
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Alumno alumno);
        [OperationContract]
        SL_WCF.Result Update(ML.Alumno alumno);
        [OperationContract]
        SL_WCF.Result Delete(ML.Alumno alumno);
    }
}
