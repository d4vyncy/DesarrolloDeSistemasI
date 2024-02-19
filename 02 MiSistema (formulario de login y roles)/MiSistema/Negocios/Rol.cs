using MiSistema.Datos;
using MiSistema.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSistema.Negocios
{
    public class Rol
    {
        public List<clsRolBE> BuscarRol(string nombreRol)
        {
            clsRolDA oclsRolDA= new clsRolDA(); 
            return oclsRolDA.BuscarRol(nombreRol);  
        }
        public clsRolBE BuscarRolPorId(int IdRol)
        {
            clsRolDA oclsRolDA = new clsRolDA();
            return oclsRolDA.BuscarRolPorId(IdRol);
        }
        public int AgregarRol(string nombreRol)
        {
            clsRolDA oclsRolDA = new clsRolDA();
            return oclsRolDA.AgregarRol(nombreRol);
        }
        public int ActualizarRol(int IdRol,string nombreRol)
        {
            clsRolDA oclsRolDA = new clsRolDA();
            return oclsRolDA.ActualizarRol(IdRol,nombreRol);
        }
    }
}
