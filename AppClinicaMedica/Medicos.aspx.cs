using System;
using System.Collections.Generic;
using System.Globalization;
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
        EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
        HorarioNegocio horarioNegocio = new HorarioNegocio();

        EspexMedNegocio especialidadesxMedico = new EspexMedNegocio();
        HorarioxMedicoNegocio horariosxMed = new HorarioxMedicoNegocio();
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

        protected void cargarListBox(int idMedico)
        {
            List<Especialidad> especialidades = especialidadNegocio.listar();
            List<EspecialidadesxMedico> listaEspXMed = especialidadesxMedico.listar().Where(em => em.IDMedico == idMedico).ToList();

            try
            {
                List<Especialidad> especialidadesEncontradas = new List<Especialidad>();

                foreach (EspecialidadesxMedico espXMed in listaEspXMed)
                {
                    Especialidad especialidadEncontrada = especialidades.FirstOrDefault(e => e.IdEspecialidad == espXMed.IDEspecialidad);

                    if (especialidadEncontrada != null)
                    {
                        especialidadesEncontradas.Add(especialidadEncontrada);
                    }
                }

                listBox.DataSource = especialidadesEncontradas;
                listBox.DataTextField = "Nombre";
                listBox.DataValueField = "IdEspecialidad";
                listBox.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de especialidades: " + ex.Message);
                throw;
            }
        }

        protected void cargarDropDownList(int idMedico)
        {
            try
            {
                List<EspecialidadesxMedico> especialidadesDelMedico = especialidadesxMedico.listar().Where(em => em.IDMedico == idMedico).ToList();

                List<Especialidad> todasLasEspecialidades = especialidadNegocio.listar();

                List<Especialidad> especialidadesNoAsignadas = todasLasEspecialidades.Where(especialidad =>
                                   !especialidadesDelMedico.Any(espMed => espMed.IDEspecialidad == especialidad.IdEspecialidad)
                                   ).ToList();

                ddlAgregarEsp.DataSource = especialidadesNoAsignadas;


                ddlAgregarEsp.DataTextField = "Nombre";
                ddlAgregarEsp.DataValueField = "IdEspecialidad";

                ddlAgregarEsp.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void cargarDropDownListHxM(int idMedico)
        {
            try
            {
                List<HorarioxMedico> horariosDelMedico = horariosxMed.listar().Where(hm => hm.IDMedico == idMedico).ToList();
                List<HorarioTrabajo> todosLosHorarios = horarioNegocio.listar();

                List<HorarioTrabajo> horariosNoAsignados = todosLosHorarios.Where(horario =>
                    !horariosDelMedico.Any(horaXMed => horaXMed.IDHorario == horario.IDHorario)
                ).ToList();

                DropDownListHxM.DataSource = horariosNoAsignados;
                DropDownListHxM.DataTextField = "HoraInicio";
                DropDownListHxM.DataValueField = "IDHorario";

                DropDownListHxM.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los horarios no asignados: " + ex.Message);
            }
        }

        protected void btnAgregarHorarioaMedico(object sender, EventArgs e)
        {
            if (DropDownListHxM.SelectedIndex != -1)
            {
                HorarioxMedico nuevoHorarioMedico = new HorarioxMedico();

                string idHorarioSeleccionado = DropDownListHxM.SelectedValue;

                int idHorario = Convert.ToInt32(idHorarioSeleccionado);
                int idMedico = Convert.ToInt32(txtId.Text);

                nuevoHorarioMedico.IDHorario = idHorario;
                nuevoHorarioMedico.IDMedico = idMedico;

                horariosxMed.agregarHorarioxMedico(nuevoHorarioMedico);

                cargarListBox(idMedico);
                cargarDropDownList(idMedico);
                cargarDropDownListHxM(idMedico);
                cargarListBoxHxM(idMedico);

            }
        }

        protected void btnEliminarHorarioaMedico(object sender, EventArgs e)
        {
            if (listBoxHxM.SelectedIndex != -1)
            {
                HorarioxMedico nuevoHorarioMedico = new HorarioxMedico();

                string valorSeleccionado = listBoxHxM.SelectedItem.Value;
                int idHorario = Convert.ToInt32(valorSeleccionado);
                int idMedico = Convert.ToInt32(txtId.Text);

                nuevoHorarioMedico.IDHorario = idHorario;
                nuevoHorarioMedico.IDMedico = idMedico;

                horariosxMed.eliminarHorarioxMedico(nuevoHorarioMedico);

                cargarListBox(idMedico);
                cargarDropDownList(idMedico);
                cargarDropDownListHxM(idMedico);
                cargarListBoxHxM(idMedico);
            }
        }

        protected void cargarListBoxHxM(int idMedico)
        {
            List<HorarioTrabajo> horarios = horarioNegocio.listar();
            List<HorarioxMedico> listaHoraxMed = horariosxMed.listar().Where(hm => hm.IDMedico == idMedico).ToList();
            try
            {
                List<HorarioTrabajo> horariosEncontrados = new List<HorarioTrabajo>();

                foreach (HorarioxMedico horaXMed in listaHoraxMed)
                {
                    HorarioTrabajo horarioEncontrado = horarios.FirstOrDefault(h => h.IDHorario == horaXMed.IDHorario);

                    if (horarioEncontrado != null)
                    {
                        string horaCompleta = $"{horarioEncontrado.HoraInicio} - {horarioEncontrado.HoraFin}";

                        listBoxHxM.Items.Add(new ListItem(horaCompleta, horarioEncontrado.IDHorario.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de horarios: " + ex.Message);
                throw;
            }
        }

        protected void dgvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dgvMedicos.SelectedRow;

            txtMatricula.Text = row.Cells[2].Text;
            txtNombre.Text = row.Cells[4].Text;
            txtApellido.Text = row.Cells[5].Text;
            txtEmail.Text = row.Cells[6].Text;
            txtCelular.Text = row.Cells[9].Text;
            txtDni.Text = row.Cells[3].Text;
            txtDomicilio.Text = row.Cells[8].Text;
            txtCodPost.Text = row.Cells[10].Text;

            int IdMedico = Convert.ToInt32(row.Cells[1].Text);

            txtId.Text = IdMedico.ToString();
            cargarListBox(IdMedico);
            cargarDropDownList(IdMedico);
            cargarListBoxHxM(IdMedico);
            cargarDropDownListHxM(IdMedico);

        }
        protected void btnBajaMedicoClick(object sender, EventArgs e)
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

        protected void btnAgregarEspecialidadaMedico(object sender, EventArgs e)

        {
            if (ddlAgregarEsp.SelectedIndex != -1)
            {
                EspecialidadesxMedico nuevaExM = new EspecialidadesxMedico();

                string idEspecialidadSeleccionada = ddlAgregarEsp.SelectedValue;

                int idEspecialidad = Convert.ToInt32(idEspecialidadSeleccionada);
                int idMedico = Convert.ToInt32(txtId.Text);

                nuevaExM.IDEspecialidad = idEspecialidad;
                nuevaExM.IDMedico = idMedico;

                especialidadesxMedico.agregarEspecialidad_x_Medico(nuevaExM);

                cargarListBox(nuevaExM.IDMedico);
                cargarDropDownList(nuevaExM.IDMedico);

            }
        }
        protected void btnEliminarEspecialidadaMedico(object sender, EventArgs e)
        {
            EspecialidadesxMedico nuevaExM = new EspecialidadesxMedico();
            if (listBox.SelectedIndex != -1)
            {



                string valorSeleccionado = listBox.SelectedItem.Value;

                int idEspecialidad = Convert.ToInt32(valorSeleccionado);
                int idMedico = Convert.ToInt32(txtId.Text);

                nuevaExM.IDEspecialidad = idEspecialidad;
                nuevaExM.IDMedico = idMedico;

                especialidadesxMedico.eliminarEspecialidad_x_Medico(nuevaExM);

                cargarListBox(nuevaExM.IDMedico);
                cargarDropDownList(nuevaExM.IDMedico);

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = txtId.Text;
                int Matricula = Convert.ToInt32(txtMatricula.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                int Dni = Convert.ToInt32(txtDni.Text);
                string Domicilio = txtDomicilio.Text;
                int celular = Convert.ToInt32(txtCelular.Text);
                int codPost = Convert.ToInt32(txtCodPost.Text);

                Medico medicoModificado = new Medico
                {
                    IdMedico = Id,
                    Matricula = Matricula,
                    Nombre = nombre,
                    Apellido = apellido,
                    Email = email,
                    Dni = Dni,
                    Celular = celular,
                    Domicilio = Domicilio,
                    CodPostal = codPost,


                };

                medicoNegocio.modificarMedico(medicoModificado);


                cargarListaMedicos();

                limpiarCampos();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al modificar el Medico: " + ex.Message);
            }


        }

        protected void limpiarCampos()
        {
            txtMatricula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtCodPost.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtDomicilio.Text = string.Empty;

        }

        protected void agregarMedico_Click(object sender, EventArgs e)
        {
            try
            {

                int Matricula = Convert.ToInt32(txtMatricula.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                int Dni = Convert.ToInt32(txtDni.Text);
                string Domicilio = txtDomicilio.Text;
                int celular = Convert.ToInt32(txtCelular.Text);
                int codPost = Convert.ToInt32(txtCodPost.Text);

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


                };

                System.Web.HttpContext.Current.Session["MedicoNuevo"] = medicoNuevo;
                Response.Redirect("NuevoMedico.aspx");

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al Agregar el Medico: " + ex.Message);
            }

        }
    }
}

