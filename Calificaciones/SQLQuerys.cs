using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Calificaciones
{
    public class SQLQuerys
    {
        string strConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        public DataTable CargarCalificaciones()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand(@"select a.id idCalificacion, a.idEstudiante, a.idMateria, b.nombre as Materia, c.apellido + ' ' + c.nombre as Estudiante,
a.int as Nota, Case when a.int >= 4 then 'Aprobado' else 'Desaprobado' end as Calificacion
from Calificaciones a, Materias b, Estudiantes c
where a.idEstudiante = c.id and a.idMateria = b.id", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            finally { con.Close(); }
        }
        public bool VerificarCalificacionExistente(int idMateria, int idEstudiante)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand(@"select count(id) result from Calificaciones
where idMateria = @idMateria and idEstudiante = @idEstudiante", con);

                cmd.Parameters.AddWithValue("@idMateria", idMateria);
                cmd.Parameters.AddWithValue("@idEstudiante", idEstudiante);
               int result =  Convert.ToInt32(cmd.ExecuteScalar());

                if(result == 0) return true;
                else return false;





            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            finally { con.Close(); }
        }

        public bool EliminarCalificacion(int idCalificacion)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand(@"delete Calificaciones where id = @idCalificacion", con);

                cmd.Parameters.AddWithValue("@idCalificacion", idCalificacion);
                cmd.ExecuteNonQuery();
                return true;

         

         

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            finally { con.Close(); }
        }
        public bool ActualizarCalificacion(int idCalificacion, int idMateria, int idEstudiante, int Nota)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand(@"update Calificaciones set idEstudiante = @idEstudiante, idMateria = @idMateria, [int] = @nota
where id = @idCalificacion", con);

                cmd.Parameters.AddWithValue("@idCalificacion", idCalificacion);
                cmd.Parameters.AddWithValue("@idMateria", idMateria);
                cmd.Parameters.AddWithValue("@idEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("@nota", Nota);
                cmd.ExecuteNonQuery();
                return true;





            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            finally { con.Close(); }
        }

        public bool VerificarRelacionMateria(int idMateria)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand(@"select Count(idMateria) result from Calificaciones
where idMateria = @idMateria", con);

                cmd.Parameters.AddWithValue("@idMateria", idMateria);
            
                int result = Convert.ToInt32(cmd.ExecuteScalar());

                if (result > 0) return true;
                else return false;





            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            finally { con.Close(); }
        }
        public bool VerificarRelacionEstudiante(int idEstudiante)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand(@"select Count(idEstudiante) result from Calificaciones
where idEstudiante = @idEstudiante", con);

                cmd.Parameters.AddWithValue("@idEstudiante", idEstudiante);

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                if (result > 0) return true;
                else return false;





            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            finally { con.Close(); }
        }

    }
}