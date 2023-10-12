using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calificaciones
{
    public partial class Frm_Estudiantes : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim())) {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "Debe ingresar el nombre.";
                return false; 
            }
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "Debe ingresar el apellido.";
                return false;
            }
            return true;
        
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (Validar())
            {
                result = SqlDSEstudiantes.Insert();
                if(result > 0)
                {
           
                    string mensaje = $"Mensaje('Estudiante Registrado!', 'El Estudiante {txtNombre.Text.Trim()}  {txtApellido.Text.Trim()} se registró correctamente.', 'success');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                  
                    txtApellido.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/logFile.txt", true);
                    streamWriter.WriteLine($"{DateTime.Now} - Estudiante Registrado Correctamente");
                    streamWriter.Close();
                }
                else
                {
             
                    string mensaje = $"Mensaje('Error!', 'El Estudiante {txtNombre.Text.Trim()}  {txtApellido.Text.Trim()} no se pudo registrar.', 'error');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                }
            }
        }
        protected void VerificarRelacion(object sender, GridViewDeleteEventArgs e)
        {

            int idEstudiante = Convert.ToInt32(gvEstudiantes.DataKeys[e.RowIndex].Value);
            SQLQuerys query = new SQLQuerys();



            if (query.VerificarRelacionEstudiante(idEstudiante))
            {
                e.Cancel = true;
                string mensaje = $"Mensaje('Error!', 'El Estudiante no se pudo eliminar ya que está registrado en las calificaciones.', 'error');";
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
            }

        }
    }
}