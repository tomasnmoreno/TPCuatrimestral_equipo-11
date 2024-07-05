using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace AppClinicaMedica
{
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio negEspecialidad = new EspecialidadNegocio();
            MedicoNegocio medEspecialidad = new MedicoNegocio();
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            PacienteNegocio pacienteNegocio = new PacienteNegocio();

            try
            {
                if (!IsPostBack)
                {
                    List<Medico> listaMedicos = medEspecialidad.listar();
                    Session["listaMedicos"] = listaMedicos;

                    List<Especialidad> listaEspecialidades = negEspecialidad.listar();
                    ddlEspecialidades.DataSource = listaEspecialidades;
                    ddlEspecialidades.DataTextField = "Nombre";
                    ddlEspecialidades.DataValueField = "IdEspecialidad";
                    ddlEspecialidades.DataBind();

                    List<Paciente> listaPacientes = pacienteNegocio.listar();
                    ddlPacientes.DataSource = listaPacientes;
                    ddlPacientes.DataTextField = "Nombre";
                    ddlPacientes.DataValueField = "IDPaciente";
                    ddlPacientes.DataBind();
                    Session.Add("listaPAcientes", listaPacientes.ToList());
                    var pies = Session["listaPacientes"];
                    //List<Turno> listaTurnos = turnoNegocio.listar();
                    //dgvTurnos.DataSource = listaTurnos;
                    //dgvTurnos.DataBind();
                    //Session.Add("listaTurnos", turnoNegocio.listar());
                    cargarDgvTurnos(0, 0);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }

        //protected void cargarDgvTurnos()
        //{

        //}

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Medico> listaMedicosFiltrados = new List<Medico>();
            try
            {
                int id = int.Parse(ddlEspecialidades.SelectedItem.Value);
                datos.setQuery("select m.apellido, m.IDUsuario from MEDICOS m inner join EspecialidadesXMedicos em on em.IDMedico = m.IDUsuario inner join Especialidades e on e.Id = em.IDEspecialidad where e.Id = @idEspecialidad");
                datos.setearParametro("@IdEspecialidad", id);
                datos.leer();

                //bool bandera = false;
                while (datos.Reader.Read())
                {
                    Medico aux = new Medico();
                    //if (!bandera)
                    //{
                    //    Medico aux2 = new Medico();
                    //    bandera = true;
                    //    aux2.Apellido = "Seleccione una opcion";
                    //    aux.IdMedico = "0";
                    //    listaMedicosFiltrados.Add(aux2);
                    //}

                    aux.IdMedico = (string)datos.Reader["IDUsuario"].ToString();
                    aux.Apellido = (string)datos.Reader["apellido"];

                    listaMedicosFiltrados.Add(aux);
                }

                // Limpiar DropDownList antes de agregar nuevos datos
                ddlMedicosFiltrados.Items.Clear();
                ddlMedicosFiltrados.DataSource = listaMedicosFiltrados;
                Session.Add("listaMedicosFiltrados", listaMedicosFiltrados.ToList());
                ddlMedicosFiltrados.DataTextField = "apellido";
                ddlMedicosFiltrados.DataValueField = "IdMedico";

                ddlMedicosFiltrados.DataBind();

                int IDEspecialidad = int.Parse(ddlEspecialidades.SelectedItem.Value);
                cargarDgvTurnos(0, IDEspecialidad);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlMedicosFiltrados_DataBound(object sender, EventArgs e)
        {
            MedicoNegocio todosLosMedico = new MedicoNegocio();
            List<Medico> medicosLista = todosLosMedico.listar();
            foreach (ListItem item in ddlMedicosFiltrados.Items)
            {
                int idMedico = Convert.ToInt32(item.Value);

                var Medico = medicosLista.FirstOrDefault(m => Convert.ToInt32(m.IdMedico) == idMedico);
                if (Medico != null)
                {

                    item.Text = $"{Medico.Nombre}  {Medico.Apellido}";
                }
            }
        }

        protected void ddlMedicosFiltrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int IDMedico = int.Parse(ddlMedicosFiltrados.SelectedItem.Value);
                cargarDgvTurnos(IDMedico, 0);
                if (ddlMedicosFiltrados.Text.ToString() != "Seleccione una opción")
                {
                    dgvTurnos_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //try
            //{
            //TurnoNegocio turnoNegocio = new TurnoNegocio();
            //int IDMedico = int.Parse(ddlMedicosFiltrados.SelectedItem.Value);
            //List<Turno> listaTurnos = turnoNegocio.listar(IDMedico);
            //dgvTurnos.DataSource = listaTurnos;
            //dgvTurnos.DataBind();
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }

        protected void cargarDgvTurnos(int IDMedico, int IDEspecialidad)
        {
            try
            {
                if (IDMedico != 0)
                {
                    Session.Add("IDMedico", IDMedico);
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = turnoNegocio.listar(IDMedico);
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.DataBind();
                }
                else
                {
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = turnoNegocio.listar();
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.DataBind();
                }

                if (IDEspecialidad != 0)
                {
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = turnoNegocio.listarPorEspecialidad(IDEspecialidad);
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.DataBind();
                }

                if (IDMedico == 0 && IDEspecialidad == 0)
                {
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = turnoNegocio.listar();
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar lista de turnos: " + ex.Message);
            }
        }

        protected void ddlMedicosFiltrados_PreRender(object sender, EventArgs e)
        {
            // Agregar un ListItem en blanco si no hay elementos seleccionados
            if (!IsPostBack || ddlMedicosFiltrados.Items.Count == 0)
            {
                ddlMedicosFiltrados.Items.Insert(0, new ListItem("Seleccione una opción", ""));

            }
            if (Session["listaMedicos"].ToString() != "" && ddlMedicosFiltrados.Items[0].Text != "Seleccione una opción" && ddlMedicosFiltrados.Items.Count >= 1) /*ddlMedicosFiltrados.Items.Count >= 1*/
            {
                ddlMedicosFiltrados.Items.Insert(0, new ListItem("Seleccione una opción", ""));
            }
            //if (ddlMedicosFiltrados.Items.Count > 2)
            //{
            //    ddlMedicosFiltrados.Items.Insert(0, new ListItem("Seleccione una opción", ""));
            //}
        }

        protected void ddlPacientes_DataBound(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            List<Paciente> listaPacientes = pacienteNegocio.listar();
            foreach (ListItem item in ddlPacientes.Items)
            {
                int IDPaciente = Convert.ToInt32(item.Value);
                var Paciente = listaPacientes.FirstOrDefault(p => Convert.ToInt32(p.IDPaciente) == IDPaciente);
                if (Paciente != null)
                {
                    item.Text = $"{Paciente.Nombre} {Paciente.Apellido}";
                }
            }


            //MedicoNegocio todosLosMedico = new MedicoNegocio();
            //List<Medico> medicosLista = todosLosMedico.listar();
            //foreach (ListItem item in ddlMedicosFiltrados.Items)
            //{
            //    int idMedico = Convert.ToInt32(item.Value);

            //    var Medico = medicosLista.FirstOrDefault(m => Convert.ToInt32(m.IdMedico) == idMedico);
            //    if (Medico != null)
            //    {

            //        item.Text = $"{Medico.Nombre}  {Medico.Apellido}";
            //    }
            //}
        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //var quesendertengo = sender.ToString();
                if(sender.ToString() == "System.Web.UI.WebControls.GridView")
                {
                //var id = dgvTurnos.SelectedDataKey.Value.ToString();
                GridViewRow row = dgvTurnos.SelectedRow;

                Label lblFecha = (Label)row.FindControl("lblFecha");
                string fecha = lblFecha.Text;
                DateTime _fecha = DateTime.Parse(fecha);
                txtFecha.Text = _fecha.ToString("yyyy-MM-dd");

                //Label lblHora = (Label)row.FindControl("lblHora");
                //string hora = lblHora.Text;
                //TimeSpan _hora = TimeSpan.Parse(hora);
                //txtHorario.Text = _hora.ToString();
                
                string hora= row.Cells[5].Text.ToString();
                TimeSpan _hora = TimeSpan.Parse(hora.ToString());
                txtHorario.Text = hora;

                txtbEleccion.Text = $"{ddlPacientes.SelectedItem.Text} - " +
                        $"Dr/Dra. {ddlMedicosFiltrados.SelectedItem.Text} - " +
                        $"{txtFecha.Text.ToString()} " +
                        $"{hora.ToString().Substring(0, 5)}hs";
                }

                else
                {
                    txtbEleccion.Text = $"{ddlPacientes.Text} - " +
                        $"Drs. {ddlMedicosFiltrados.SelectedItem.Text.ToString()} " +
                        $"| {txtFecha.Text.ToString()} " +
                        $"{txtHorario.Text.ToString()}hs.";
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ddlPacientes_PreRender(object sender, EventArgs e)
        {
            //if (ddlPacientes.Items.Count > 0 && ddlPacientes.Items[0].Text != "Seleccione una opción")
            if (!IsPostBack)
            {
                ddlPacientes.Items.Insert(0, new ListItem("Seleccione una opción", ""));
            }
        }
        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            if (txtFecha.Text != "")
               dgvTurnos_SelectedIndexChanged(sender, e);
        }

        protected void txtHorario_TextChanged(object sender, EventArgs e)
        {
            if (txtHorario.Text != "")
                dgvTurnos_SelectedIndexChanged(sender, e);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            //tengo que tomar los valores de todos los campos y parsearlos si es necesario () AH NO PARA
            // --> SOLO TOMO EL ID DEL PACIENTE Y DEL TURNO (celda grid de nro turno) y UPDATE SQL en tabla Turnos Where IDTurno = @IDTurno {setear parametro}
            
            int IDPaciente = Convert.ToInt32(ddlPacientes.SelectedItem.Value);
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            List<Turno> listaTurnos = turnoNegocio.listar(int.Parse(Session["IDMedico"].ToString()));
            //if(txtHorario.Text.ToString() == listaTurnos) // VALIDACION
            //int IDTurno = 

            //tengo que meter los datos a la base de datos
        }
    }
}