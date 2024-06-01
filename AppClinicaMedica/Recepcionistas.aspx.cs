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
    public partial class Recepcionistas : System.Web.UI.Page
    {
        public List<Recepcionista> listaRecepcionistas;
        public RecepcionistaNegocio ReNegocio; 

        protected void Page_Load(object sender, EventArgs e)
        {
            ReNegocio = new RecepcionistaNegocio();
            listaRecepcionistas = ReNegocio.listar();

            dgvRecepcionistas.DataSource = listaRecepcionistas;
            dgvRecepcionistas.DataBind();
        }
    }
}