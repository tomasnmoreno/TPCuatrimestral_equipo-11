using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppClinicaMedica
{
    public partial class Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            PacienteNegocio negocio = new PacienteNegocio();
            dgvPacientes.DataSource = negocio.listar();
            dgvPacientes.DataBind();

            Session.Add("listaPacientes", negocio.listar());            
            }
        }

        protected void dgvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvPacientes.SelectedDataKey.Value.ToString();
            Response.Redirect("NuevoPaciente.aspx?IDUsuario=" + id);
        }
    }
}