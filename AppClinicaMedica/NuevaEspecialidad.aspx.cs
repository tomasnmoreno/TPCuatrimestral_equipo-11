using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace AppClinicaMedica
{
    public partial class NuevaEspecialidad : System.Web.UI.Page
    {
        private Especialidad especialidad = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            EspecialidadNegocio negocio = new EspecialidadNegocio();    
            try
            {
                if(especialidad == null)
                {
                    especialidad = new Especialidad();  
                    especialidad.Nombre = txtEspecialidad.Text;
                    especialidad.Descripcion = txtDescripcionEspecialidad.Text;
                    especialidad.Imagen = txtImagenNuevaEspecialidad.Text;
                }

                if(especialidad.Nombre != "")
                {
                    negocio.agregarEspecialidad(especialidad); 
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}