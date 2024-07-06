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

        public Usuario(string user, string pass, int tipo)
        {
            NombreUsuario = user;
            Pass = pass;
            //TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario;
            switch (tipo)
            {
                case 1: TipoUsuario = TipoUsuario.ADMIN;
                    break;
                case 2: TipoUsuario = TipoUsuario.RECEP;
                    break;
                case 3: TipoUsuario = TipoUsuario.MEDICO;
                    break;
                case 4: TipoUsuario = TipoUsuario.PACIENTE;
                    break;
                default: 
                    break;
            }
        }
    }
}
