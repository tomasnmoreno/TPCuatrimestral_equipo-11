using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace AppClinicaMedica
{
    public partial class Medicos : System.Web.UI.Page
    {
        MedicoNegocio medicoNegocio = new MedicoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarListaMedicos();
            }

        }
        protected void cargarListaMedicos()
        {
            try
            {
                List<Medico> lista = medicoNegocio.listar();


                dgvMedicos.DataSource = lista;
                dgvMedicos.DataBind();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de medicos: " + ex.Message);
            }

        }
        protected void dgvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dgvMedicos.SelectedRow;

            int IdMedico = Convert.ToInt32(row.Cells[1].Text);

            txtId.Text = IdMedico.ToString();

        }
        protected void btnBajaMedico_Click(object sender, EventArgs e)
        {
            MedicoNegocio negocio = new MedicoNegocio();

            try
            {
                int id = int.Parse(txtId.Text.ToString());
                negocio.bajaMedico(id);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}