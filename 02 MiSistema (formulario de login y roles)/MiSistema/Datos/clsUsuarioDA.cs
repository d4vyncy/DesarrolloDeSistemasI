using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiSistema.Entidades;
using System.Data.SqlClient;
using System.IO;
namespace MiSistema.Datos
{
    public class clsUsuarioDA:clsUsuarioBE
    {
        private string cadenaDeConexion;
        public  clsUsuarioDA()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiProyecto"].ConnectionString;
        }
        public  clsUsuarioBE GetPorNombreUsuario(string nombreusuario)
        {            
            clsUsuarioBE oclsUsuarioBE = new clsUsuarioBE();
            oclsUsuarioBE.IdUsuario = 0;//si el usuario no existe su id sera igual a cero
            using (SqlConnection conn = new SqlConnection(cadenaDeConexion))
            {
                 conn.Open();
                SqlCommand cmd = new SqlCommand("select * from trnUsuario where NombreUsuario='"
                    + nombreusuario + "';", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oclsUsuarioBE.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
                        oclsUsuarioBE.NombreUsuario = reader["NombreUsuario"].ToString();
                        oclsUsuarioBE.Clave = reader["Clave"].ToString();
                        oclsUsuarioBE.Salt = reader["Salt"].ToString();
                    }
                }
            }
            return oclsUsuarioBE;
        }
    }
}
