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
    public partial class Frm_Materias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(txtMateria.Text.Trim()))
            {

                result = SqldsMaterias.Insert();
                if(result > 0)
                {
                    string mensaje = $"Mensaje('Materia Registrada!', 'La Materia {txtMateria.Text.Trim()} se registró correctamente.', 'success');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                    txtMateria.Text = string.Empty;
                    StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/logFile.txt", true);
                    streamWriter.WriteLine($"{DateTime.Now} - Materia Registrada Correctamente");
                    streamWriter.Close();
                }
                else
                {
                    string mensaje = $"Mensaje('Error!', 'La Materia {txtMateria.Text.Trim()} no se pudo registrar.', 'error');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
                }
            }
            else
            {
                lblinfo.ForeColor = Color.Red;
                lblinfo.Text = "Debe ingresar el nombre de una Materia.";
            }
        }
        protected void VerificarRelacion(object sender, GridViewDeleteEventArgs e)
        {
           
            int idMateria = Convert.ToInt32(GvMaterias.DataKeys[e.RowIndex].Value);
            SQLQuerys query = new SQLQuerys();

         
    
            if (query.VerificarRelacionMateria(idMateria))
            {
                e.Cancel = true; 
                string mensaje = $"Mensaje('Error!', 'La Materia no se pudo eliminar ya que está registrada en las calificaciones.', 'error');";
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", mensaje, true);
            }
       
        }

   

    }
}