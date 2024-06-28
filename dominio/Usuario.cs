using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        ADMIN = 1,
        RECEP = 2,
        MEDICO = 3,
        PACIENTE = 4
    }
    public class Usuario
    {
        public int ID { get; set; }

        public string NombreUsuario { get; set; }

        public string Pass { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public Usuario(string user, string pass, bool admin)
        {
            NombreUsuario = user;
            Pass = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario;
        }
    }
}
