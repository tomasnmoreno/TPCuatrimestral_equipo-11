using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppClinicaMedica
{
    public partial class NuevoPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IDUsuario"] != null && !IsPostBack) /*Evalua si me estoy trayendo id en la url*/
            {
                int id = int.Parse(Request.QueryString["IDUsuario"].ToString());

                List<Paciente> temporal = (List<Paciente>)Session["listaPacientes"];
                Paciente seleccionado = temporal.Find(x => x.IDPaciente == id);
                txtUsuario.Text = seleccionado.NombreUsuario;
                txtPass.Text = seleccionado.Pass;
                txtNombre.Text = seleccionado.Nombre;
                txtApellido.Text = seleccionado.Apellido;
                txtNacimiento.Text = seleccionado.FechaDeNacimiento.ToString();
                //txtNacimiento.Text = seleccionado.FechaDeNacimiento.ToString("dd-MM-yyyy");
                txtDNI.Text = (string)seleccionado.Dni.ToString();
                txtEmail.Text = seleccionado.Email.ToString();
                txtCelular.Text = seleccionado.Celular.ToString();
                txtDomicilio.Text = seleccionado.Domicilio;
                txtCodPostal.Text = seleccionado.CodPostal.ToString();
            }

        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
            PacienteNegocio negocio = new PacienteNegocio();
            Paciente paciente = new Paciente();
            string id = Request.QueryString["IDUsuario"] != null ? Request.QueryString["IDUsuario"].ToString() : "";


            paciente.NombreUsuario = txtUsuario.Text;
            paciente.Pass = txtPass.Text;
            paciente.Nombre = txtNombre.Text;
            paciente.Apellido = txtApellido.Text;
            //paciente.Dni = txtDNI.Text;
            paciente.Dni = Convert.ToInt64(txtDNI.Text);
            //paciente.FechaDeNacimiento = txtNacimiento.Text;
            paciente.FechaDeNacimiento = DateTime.Parse(txtNacimiento.Text);
            paciente.Email = txtEmail.Text;
            paciente.Celular = Convert.ToInt64(txtCelular.Text);
            paciente.Domicilio = txtDomicilio.Text;
            paciente.CodPostal = int.Parse(txtCodPostal.Text);

                if (id != "") /*Evalua si me estoy trayendo id en la url*/
                {
                    paciente.IDPaciente = int.Parse(id);
                    //negocio.modificarPacienteSP(paciente);
                    negocio.modificarPaciente(paciente);
                }
                else
                {
                    negocio.agregarPaciente(paciente);
                }

                Response.Redirect("Pacientes.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBajaPaciente_Click(object sender, EventArgs e)
        {
            try
            {
            PacienteNegocio negocio = new PacienteNegocio();
            Paciente paciente = new Paciente();

                string id = Request.QueryString["IDUsuario"] != null ? Request.QueryString["IDUsuario"].ToString() : "";
            if (id != "") /*Evalua si me estoy trayendo id en la url*/
            {
                    paciente.IDPaciente = int.Parse(id);
                    negocio.bajaPaciente(paciente.IDPaciente);
            }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}