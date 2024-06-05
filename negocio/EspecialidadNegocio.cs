﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> listar()
        {
            List<Especialidad> listaEspecialidades = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("SELECT ID, NOMBRE, DESCRIPCION, IMAGEN FROM ESPECIALIDADES ORDER BY DESCRIPCION ASC");
                datos.leer();

                while(datos.Reader.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.IdEspecialidad = (int)datos.Reader["ID"];
                    aux.Nombre = (string)datos.Reader["NOMBRE"];
                    aux.Descripcion = (string)datos.Reader["Descripcion"];
                    aux.Imagen = (string)datos.Reader["Imagen"];

                    listaEspecialidades.Add(aux);
                }
                return listaEspecialidades;
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
