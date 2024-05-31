using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace AppClinicaMedica
{
    public partial class Especialidades : System.Web.UI.Page
    {
        public List<Especialidad> listaEspecialidades;
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            listaEspecialidades = especialidadNegocio.listar();

            ddlEspecialidades.DataSource = listaEspecialidades;
            ddlEspecialidades.DataTextField = "Nombre";
            ddlEspecialidades.DataBind();
        }
    }
}