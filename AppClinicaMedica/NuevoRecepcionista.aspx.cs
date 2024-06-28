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
    public partial class NuevoRecepcionista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IDUsuario"] != null && !IsPostBack) /*Evalua si me estoy trayendo id en la url*/
            {
                int id = int.Parse(Request.QueryString["IDUsuario"].ToString());

                List<Recepcionista> temporal = (List<Recepcionista>)Session["listaRecepcionistas"];
                Recepcionista seleccionado = temporal.Find(x => x.IDRecepcionista == id);
                txtUsuario.Text = seleccionado.NombreUsuario;
                txtPass.Text = seleccionado.Pass.ToString();
                txtNombre.Text = seleccionado.Nombre;
                txtApellido.Text = seleccionado.Apellido;
                txtNacimiento.Text = seleccionado.FechaDeNacimiento.ToString();
                //DateTime nac = DateTime.Parse(seleccionado.FechaDeNacimiento.ToString("yyyy-MM-dd"));
                txtNacimiento.Text = seleccionado.FechaDeNacimiento.ToString("yyyy-MM-dd").ToString();
                txtDNI.Text = (string)seleccionado.Dni.ToString();
                txtEmail.Text = seleccionado.Email.ToString();
                txtCelular.Text = seleccionado.Celular.ToString();
                txtDomicilio.Text = seleccionado.Domicilio;
                txtCodPostal.Text = seleccionado.CodPostal.ToString();
            }
        }
        protected void btnAgregarRecepcionista_Click(object sender, EventArgs e)
        {
            try
            {
                RecepcionistaNegocio negocio = new RecepcionistaNegocio();
                Recepcionista recepcionista = new Recepcionista();
                string id = Request.QueryString["IDUsuario"] != null ? Request.QueryString["IDUsuario"].ToString() : "";


                recepcionista.NombreUsuario = txtUsuario.Text;
                recepcionista.Pass = txtPass.Text;
                recepcionista.Nombre = txtNombre.Text;
                recepcionista.Apellido = txtApellido.Text;
                //paciente.Dni = txtDNI.Text;
                recepcionista.Dni = Convert.ToInt64(txtDNI.Text);
                //paciente.FechaDeNacimiento = txtNacimiento.Text;
                recepcionista.FechaDeNacimiento = DateTime.Parse(txtNacimiento.Text);
                recepcionista.Email = txtEmail.Text;
                recepcionista.Celular = Convert.ToInt64(txtCelular.Text);
                recepcionista.Domicilio = txtDomicilio.Text;
                recepcionista.CodPostal = int.Parse(txtCodPostal.Text);

                if (id != "") /*Evalua si me estoy trayendo id en la url*/
                {
                    recepcionista.IDRecepcionista = int.Parse(id);
                    //negocio.modificarPacienteSP(paciente);
                    negocio.modificarRecepcionista(recepcionista);
                }
                else
                {
                    negocio.agregarRecepcionista(recepcionista);
                }

                Response.Redirect("Recepcionistas.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBajaRecepcionista_Click(object sender, EventArgs e)
        {
            try
            {
                RecepcionistaNegocio negocio = new RecepcionistaNegocio();
                Recepcionista recepcionista = new Recepcionista();

                string id = Request.QueryString["IDUsuario"] != null ? Request.QueryString["IDUsuario"].ToString() : "";
                if (id != "") /*Evalua si me estoy trayendo id en la url*/
                {
                    recepcionista.IDRecepcionista = int.Parse(id);
                    negocio.bajaRecepcionistaFisica(recepcionista.IDRecepcionista);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}