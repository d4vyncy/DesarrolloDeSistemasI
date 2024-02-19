using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSistema.Entidades
{
    public class clsRolUsuarioBE
    {
        public int IdRolUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstadoRolUsuario { get; set; }
        public int IdTipoRolUsuario { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
