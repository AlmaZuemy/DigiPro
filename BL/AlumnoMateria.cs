using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnoMateriaGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableAlumnoMateria = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumnoMateria);

                        if (tableAlumnoMateria.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableAlumnoMateria.Rows)
                            {
                                ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                                alumnomateria.Alumno = new ML.Alumno();
                                alumnomateria.Alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumnomateria.Alumno.Nombre = row[1].ToString();
                                alumnomateria.Alumno.ApellidoPaterno = row[2].ToString();
                                alumnomateria.Alumno.ApellidoMaterno = row[3].ToString();

                                result.Objects.Add(alumnomateria);

                            }
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
            }

            return result;
        }

        public static ML.Result MateriasAsignadas(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "MateriasAsignadas";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tableAlumnoMateria = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumnoMateria);

                        if (tableAlumnoMateria.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableAlumnoMateria.Rows)
                            {
                                ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                                alumnomateria.Alumno = new ML.Alumno();
                                alumnomateria.Alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumnomateria.Alumno.Nombre = row[1].ToString();
                                alumnomateria.Alumno.ApellidoPaterno = row[2].ToString();
                                alumnomateria.Alumno.ApellidoMaterno = row[3].ToString();
                                alumnomateria.Materia = new ML.Materia();
                                alumnomateria.Materia.IdMateria = int.Parse(row[4].ToString());
                                alumnomateria.Materia.Nombre = row[5].ToString();

                                result.Objects.Add(alumnomateria);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result MateriasSinAsignar(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "MateriasNoAsignadas";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tableAlumnoMateria = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumnoMateria);

                        if (tableAlumnoMateria.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableAlumnoMateria.Rows)
                            {
                                ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                                alumnomateria.Materia = new ML.Materia();
                                alumnomateria.Materia.IdMateria = int.Parse(row[0].ToString());
                                alumnomateria.Materia.Nombre = row[1].ToString();
                                alumnomateria.Materia.Costo = decimal.Parse(row[2].ToString());

                                result.Objects.Add(alumnomateria);
                            }
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
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnoGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tablaUsuario = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaUsuario);

                        if (tablaUsuario.Rows.Count > 0)
                        {
                            DataRow row = tablaUsuario.Rows[0];

                            ML.AlumnoMateria alumno = new ML.AlumnoMateria();
                            alumno.Alumno = new ML.Alumno();
                            alumno.Alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Alumno.Nombre = row[1].ToString();
                            alumno.Alumno.ApellidoPaterno = row[2].ToString();
                            alumno.Alumno.ApellidoMaterno = row[3].ToString();
                            alumno.Materia = new ML.Materia();
                            alumno.Materia.IdMateria = int.Parse(row[4].ToString());
                            alumno.Materia.Nombre = row[5].ToString();
                            result.Object = alumno;
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
            }
            return result;
        }

        public static ML.Result Add(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnoMateriaAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("@IdAlumno", SqlDbType.VarChar);
                        collection[0].Value = alumnoMateria.Alumno.IdAlumno;

                        collection[1] = new SqlParameter("@IdMateria", SqlDbType.VarChar);
                        collection[1].Value = alumnoMateria.Materia.IdMateria;
                        cmd.Parameters.AddRange(collection);
                        context.Open();
                        int RawsAffected = cmd.ExecuteNonQuery();

                        if (RawsAffected > 0)
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

        public static ML.Result Delete(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnoMateriaDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdAlumnoMateria", SqlDbType.Int);
                        collection[0].Value = alumnoMateria.IdAlumnoMateria;

                        cmd.Parameters.AddRange(collection);
                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
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
    }
}
