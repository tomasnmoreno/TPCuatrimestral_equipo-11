using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppClinicaMedica
{
    public partial class NuevoMedico : System.Web.UI.Page
    {

        MedicoNegocio medicoNegocio = new MedicoNegocio(); 
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            try
            {
                Medico medicoRecuperado = System.Web.HttpContext.Current.Session["MedicoNuevo"] as Medico;

                if (medicoRecuperado != null)
                {
                    medicoRecuperado.Contraseña = txtPass.Text;
                    medicoRecuperado.Usuario = txtUsuario.Text;
                    medicoRecuperado.FechaDeNacimiento= DateTime.Parse(txtNacimiento.Text);
                    medicoNegocio.agregarMedico(medicoRecuperado);
                    Response.Redirect("NuevoMedico.aspx");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}