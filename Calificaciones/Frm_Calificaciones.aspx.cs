using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace Calificaciones
{
    public partial class Frm_Calificaciones : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCalificaciones();
                DVCalificaciones.DataBind();

            }
        }

       
        protected void txtCalificacion_TextChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(txtCalificacion.Text) < 0)
                txtCalificacion.Text = "0";
            if (Convert.ToInt32(txtCalificacion.Text) >= 10)
                txtCalificacion.Text = "10";
        }
        private void cargarCalificaciones()
        {
            SQLQuerys cargar = new SQLQuerys();

            DVCalificaciones.DataSource = "";
            DVCalificaciones.DataBind();
            DVCalificaciones.DataSource = cargar.CargarCalificaciones();
            DVCalificaciones.DataBind();

      


        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtCalificacion.Text))
            {
                string mensaje = $"Mensaje('Información', 'Debe ingresar la Nota.', 'info');";
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                return false;
            }
            else return true;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            SQLQuerys action = new SQLQuerys();
            int idAlumno = Convert.ToInt32(ddlAlumno.SelectedValue);
            int idMateria = Convert.ToInt32(ddlMateria.SelectedValue);
            if (!action.VerificarCalificacionExistente(idMateria, idAlumno))
            {
                string mensaje = $"Mensaje('Error', 'La Calificación de la materia {ddlMateria.SelectedItem.Text.Trim()} para el Alumno {ddlAlumno.SelectedItem.Text.Trim()} ya se encuentra registrada.', 'error');";
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                return;
            }


                if (Validar())
            {

               int result = sqlDSCalificaciones.Insert();

                if(result > 0)
                {
                    cargarCalificaciones();
                    DVCalificaciones.DataBind();
                    string mensaje = $"Mensaje('Calificación Registrada', 'La Calificación se registró Correctamente para el alumno: {ddlAlumno.SelectedItem.Text}', 'success');";
                    ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", mensaje, true);
                    StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/logFile.txt", true);
                    streamWriter.WriteLine($"{DateTime.Now} - Calificación Registrada Correctamente");
                    streamWriter.Close();
                }
                else
                {

                }
            }
        }

        protected void DVCalificaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;

          
                    Label Nota = (Label)e.Row.FindControl("lblNota");




                if (Convert.ToInt32(Nota.Text) >= 4)
                {
                    e.Row.Cells[6].ForeColor = Color.Green;
                }
                else
                {
                    e.Row.Cells[5].ForeColor = Color.Red;
                    e.Row.Cells[6].ForeColor = Color.Red;
                }

            }
        }

        protected void DVCalificaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] parametros = e.CommandArgument.ToString().Split(',');
            //if (e.CommandName == "seleccionar")
            //{
            //    string[] parametros = e.CommandArgument.ToString().Split(',');
            //    lblIdCalificacion.Text = parametros[0];
            //    ddlMateria.SelectedValue = parametros[2];
            //    ddlAlumno.SelectedValue = parametros[1];
            //    txtCalificacion.Text = parametros[3];


            //}
            if (e.CommandName == "seleccionar")
            {
                string filaId = parametros[0]; // Supongamos que el primer parámetro es el ID único de la fila

                // Busca la fila previamente seleccionada y elimina la clase CSS
                foreach (GridViewRow row in DVCalificaciones.Rows)
                {
                    if (row.CssClass == "selectedRow")
                    {
                        row.CssClass = "";
                        break; // Solo necesitas deseleccionar una fila a la vez, por lo que puedes salir del bucle.
                    }
                }

                GridViewRow selectedRow = null;

                foreach (GridViewRow row in DVCalificaciones.Rows)
                {
                    // Encuentra el control Label dentro de la celda de plantilla
                    Label lblidCalificacion = row.FindControl("lblidCalificacion") as Label;

                    if (lblidCalificacion != null && lblidCalificacion.Text == filaId)
                    {
                        selectedRow = row;
                        break;
                    }
                }

                if (selectedRow != null)
                {
                    // Aplica la clase CSS a la fila seleccionada
                    selectedRow.CssClass = "selectedRow";

                    // Resto de tu lógica para mostrar los detalles de la fila seleccionada
                    lblIdCalificacion.Text = parametros[0];
                    ddlMateria.SelectedValue = parametros[2];
                    ddlAlumno.SelectedValue = parametros[1];
                    txtCalificacion.Text = parametros[3];
                }
            }

            if (e.CommandName == "borrar")
            {
                SQLQuerys action = new SQLQuerys();
              
                string[] parmas = e.CommandArgument.ToString().Split(',');

                int idCalificacion = Convert.ToInt32(parmas[0]);
                int idAlumno = Convert.ToInt32(parmas[1]);
                int idMateria = Convert.ToInt32(parmas[2]);
                string alumno = parmas[3];

                if(action.VerificarCalificacionExistente(idMateria, idAlumno))
                {
                    string mensaje = $"Mensaje('Error', 'La Calificación no se encuentra registrada y no se puede eliminar.', 'error');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                    return;
                }
             

                if (action.EliminarCalificacion(idCalificacion))
                {
                    string mensaje = $"Mensaje('Calificación Borrada', 'La Calificación de {alumno} se borró Correctamente', 'success');";
                    cargarCalificaciones();
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                    StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/logFile.txt", true);
                    streamWriter.WriteLine($"{DateTime.Now} - Calificación Eliminada Correctamente");
                    streamWriter.Close();
                }
                else
                {
                    string mensaje = $"Mensaje('Error', 'La Calificación de {alumno} no se pudo eliminar.', 'error');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                    StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/logFile.txt", true);
                    streamWriter.WriteLine($"{DateTime.Now} - La Calificación no se pudo Eliminar");
                    streamWriter.Close();
                }
            
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            SQLQuerys action = new SQLQuerys();
            int idCalificacion = Convert.ToInt32(lblIdCalificacion.Text);
            int idAlumno = Convert.ToInt32(ddlAlumno.SelectedValue);
            int idMateria = Convert.ToInt32(ddlMateria.SelectedValue);
            if (action.VerificarCalificacionExistente(idMateria, idAlumno))
            {
                string mensaje = $"Mensaje('Error', 'La Calificación que intenta actualizar no se encuentra registrada.', 'error');";
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                return;
            }
            if(Convert.ToInt32(lblIdCalificacion.Text) == 0)
            {
                string mensaje = $"Mensaje('Error', 'Debe Seleccionar una Calificación para poder editarla.', 'error');";
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                return;
            }

            if(!Validar())  return;
           

            if(action.ActualizarCalificacion(idCalificacion, idMateria, idAlumno, Convert.ToInt32(txtCalificacion.Text)))
            {
                string mensaje = $"Mensaje('Calificación Actualizada!', 'La Calificación de la materia {ddlMateria.SelectedItem.Text.Trim()} se Actualizó correctamente para el Alumno {ddlAlumno.SelectedItem.Text.Trim()}.', 'success');";
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                lblIdCalificacion.Text = "0";
                cargarCalificaciones();
                DVCalificaciones.DataBind();
                StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/logFile.txt", true);
                streamWriter.WriteLine($"{DateTime.Now} - Calificación Actualizada Correctamente");
                streamWriter.Close();
            }
            else
            {
                StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/logFile.txt", true);
                streamWriter.WriteLine($"{DateTime.Now} - La Calificación no se pudo Acutualizar");
                streamWriter.Close();
            }
        }
    }
}