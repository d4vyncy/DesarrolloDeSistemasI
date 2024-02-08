using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winMiProyecto.Entidades;
using System.Data.SqlClient;
using System.IO;

namespace winMiProyecto.Datos
{
    public class UsuarioDA
    {
        private string cadenaDeConexion;
        public UsuarioDA()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiProyecto"].ConnectionString;
        }
        List<Usuario> list = new List<Usuario>();
        public List<Usuario> GetListPrueba()
        {            
            Usuario l1 = new Usuario();
            l1.IdUsuario = 1;
            l1.NombreUsuario = "David";
            l1.Clave = "12345678";
            l1.Salt = "d4vyncy";
            list.Add(l1);
            Usuario l2 = new Usuario();
            l2.IdUsuario = 2;
            l2.NombreUsuario = "Juan";
            l2.Clave = "12345678";
            l2.Salt = "d4vyncy";
            list.Add(l2);
            return list;
        }
        public Usuario ValidaLogin(string NombreUsuario,string Clave)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.IdUsuario = 0;
            foreach (Usuario objLista in list)
            {
                if(objLista.NombreUsuario==NombreUsuario && objLista.Clave==Clave)
                {
                    oUsuario.IdUsuario = objLista.IdUsuario;
                    oUsuario.Salt = objLista.Salt;
                }
            }
            return oUsuario;
        }
        public List<Usuario> GetList()
        {
            List<Usuario> listUsuario = new List<Usuario>();
            Usuario l;
            using (SqlConnection conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from trnUsuario; ", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        l = new Usuario();
                        l.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        l.NombreUsuario = Convert.ToString(reader["NombreUsuario"]);
                        l.Clave = Convert.ToString(reader["Clave"]);
                        listUsuario.Add(l);
                    }
                }
            }
            return listUsuario;
        }
    }
}
