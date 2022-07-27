using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        
            public static ML.Result Add(ML.Alumno alumno)
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                    {
                        var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Email, alumno.Password);

                        if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se ha podido realizar el insert";
                        }
                        result.Correct = true;
                    }
                }

                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }
            public static ML.Result Update(ML.Alumno alumno)
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                    {
                        var query = context.AlumnoUpdate(alumno.IdAlumno, alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Email, alumno.Password);

                    if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se ha podido realizar el update";
                        }
                        result.Correct = true;
                    }
                }

                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }
            public static ML.Result Delete(ML.Alumno alumno)
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                    {
                        var query = context.AlumnoDelete(alumno.IdAlumno);

                        if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se ha podido realizar el insert";
                        }
                        result.Correct = true;
                    }
                }

                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }
            public static ML.Result GetById(int IdAlumno)
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                    {
                        var obj = context.AlumnoGetById(IdAlumno).FirstOrDefault();
                        result.Objects = new List<object>();

                        if (obj != null)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.Email = obj.Email;
                            alumno.Password = obj.Password;

                            result.Object = alumno;
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo realizar la consulta";
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
            public static ML.Result GetAll()
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                    {
                        var query = context.AlumnoGetAll().ToList();
                        result.Objects = new List<object>();
                        if (query != null)
                        {
                            foreach (var obj in query)
                            {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.Email = obj.Email;
                            alumno.Password = obj.Password;

                            result.Objects.Add(alumno);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se ha podido realizar la consulta";

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
        public static ML.Result GetByIdEmail(string Email)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                {
                    var obj = context.GetByEmail(Email).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = obj.IdAlumno;
                        alumno.Email = obj.Email;
                        alumno.Password = obj.Password;

                        result.Object = alumno;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
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

