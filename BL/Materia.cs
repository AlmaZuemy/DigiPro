using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AAnayaDigiProEntities context = new DL_EF.AAnayaDigiProEntities())
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AAnayaDigiProEntities context = new DL_EF.AAnayaDigiProEntities())
                {
                    var query = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo.Value;

                            result.Objects.Add(materia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int IdMateria)
        {//SQL Client
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AAnayaDigiProEntities context = new DL_EF.AAnayaDigiProEntities())
                {
                    {
                        var query = context.MateriaDelete(IdMateria);

                        result.Objects = new List<object>();

                        if (query > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Materia materia)
        {//SQL Client
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AAnayaDigiProEntities context = new DL_EF.AAnayaDigiProEntities())
                {
                    var query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);

                    result.Objects = new List<object>();

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AAnayaDigiProEntities context = new DL_EF.AAnayaDigiProEntities())
                {
                    var obj = context.MateriaGetById(IdMateria).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = obj.IdMateria;
                        materia.Nombre = obj.Nombre;
                        materia.Costo = obj.Costo.Value;

                        result.Object = materia;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
