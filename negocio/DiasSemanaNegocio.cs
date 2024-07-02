using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class DiasSemanaNegocio { 
         public List<DiasSemana> listar()
    {
        List<DiasSemana> listaDias = new List<DiasSemana>();
        AccesoDatos datos = new AccesoDatos();

        try
        {
            datos.setQuery("SELECT Id, NOMBRE FROM DiasSemana");
            datos.leer();

            while (datos.Reader.Read())
            {
                DiasSemana aux = new DiasSemana();
                aux.IdDias = (int)datos.Reader["Id"];
                aux.Nombre = (string)datos.Reader["Nombre"];


                listaDias.Add(aux);
            }
            return listaDias;
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
