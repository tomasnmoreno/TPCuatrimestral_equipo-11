using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppClinicaMedica
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        TurnoNegocio Negocio = new TurnoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTurnos();
        }
        
        public void CargarTurnos()
        {
            int IDMedico = Convert.ToInt32(Session["IDUsuario"]);
            List<Turno> LISTA = Negocio.listar(IDMedico).Where(t=>t.paciente.Nombre !="Sin Asignar").ToList();
            dgvMisTurnos.DataSource = LISTA;
            dgvMisTurnos.DataBind();

        }

        protected void dgvMisTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dgvMisTurnos.SelectedRow;
            int IdTurno = Convert.ToInt32(row.Cells[0].Text);
            Session.Add("IdTurno", IdTurno);
            Response.Redirect("ModificarEstado.aspx");

        }
    }
}