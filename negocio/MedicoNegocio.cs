﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MedicoNegocio
    {
        public List<Medico> listar()
        {
            List<Medico> listaMedico = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("SELECT Idusuario, Matricula, Nombre, Apellido, Email, Nacimiento, Dni, Celular, Domicilio, CodPostal, U.Estado FROM MEDICOS, Usuarios U where MEDICOS.IDUsuario=U.ID AND U.Estado = 1");
                datos.leer();

                while (datos.Reader.Read())
                {
                    Medico aux = new Medico();
                    aux.IdMedico = datos.Reader["Idusuario"].ToString();
                    aux.Matricula = (int)datos.Reader["Matricula"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.Email = (string)datos.Reader["Email"];  
                    aux.FechaDeNacimiento = (DateTime)datos.Reader["Nacimiento"];
                    aux.Dni = (Int64)datos.Reader["Dni"];
                    aux.Celular = (Int64)datos.Reader["Celular"];
                    aux.Domicilio = (string)datos.Reader["Domicilio"];
                    aux.CodPostal = (int)datos.Reader["CodPostal"];


                    listaMedico.Add(aux);
                }
                return listaMedico;
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

        public void bajaMedico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setQuery("UPDATE Usuarios SET ESTADO = 0 WHERE ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
