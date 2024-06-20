using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class HorarioxMedicoNegocio
    {
        public List<HorarioxMedico> listar()
        {

            AccesoDatos datos = new AccesoDatos();
            List<HorarioxMedico> listaHxM = new List<HorarioxMedico>();

            try
            {
                datos.setQuery("SELECT IDHorario, IDMedico FROM HorarioxMedico");
                datos.leer();

                while (datos.Reader.Read())
                {
                    HorarioxMedico aux = new HorarioxMedico();
                    aux.IDHorario = (int)datos.Reader["IDHorario"];
                    aux.IDMedico = (int)datos.Reader["IDMedico"];

                    listaHxM.Add(aux);
                }

                return listaHxM;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
