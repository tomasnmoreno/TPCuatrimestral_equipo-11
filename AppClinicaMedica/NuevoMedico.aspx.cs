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
        EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
        HorarioNegocio horarioNegocio = new HorarioNegocio();

        EspexMedNegocio especialidadesxMedico = new EspexMedNegocio();
        List<Medico> Medicos = new List<Medico>();
        HorarioxMedicoNegocio horariosxMed = new HorarioxMedicoNegocio();

        public void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAgregarMedico_Click1(object sender, EventArgs e)
        {
            try
            {
                {
                    int Matricula = Convert.ToInt32(txtMatricula.Text);
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string email = txtEmail.Text;
                    int Dni = Convert.ToInt32(txtDni.Text);
                    string Domicilio = txtDomicilio.Text;
                    int celular = Convert.ToInt32(txtCelular.Text);
                    int codPost = Convert.ToInt32(txtCodPost.Text);
                    string Contra = txtPass.Text;
                    string Usuario = txtUsuario.Text;
                    DateTime FechaNac = DateTime.Parse(txtNacimiento.Text);


                    Medico medicoNuevo = new Medico
                    {
                        Matricula = Matricula,
                        Nombre = nombre,
                        Apellido = apellido,
                        Email = email,
                        Dni = Dni,
                        Celular = celular,
                        Domicilio = Domicilio,
                        CodPostal = codPost,
                        Contraseña = Contra,
                        Usuario = Usuario,
                        FechaDeNacimiento = FechaNac,

                    };

                    medicoNegocio.agregarMedico(medicoNuevo);
                                     
                    Response.Redirect("Medicos.aspx");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}