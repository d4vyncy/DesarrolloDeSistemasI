using MiSistema.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSistema.Datos
{
    public class clsRolDA
    {
        private string cadenaDeConexion;
        public clsRolDA()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiProyecto"].ConnectionString;
        }
        public List<clsRolBE> BuscarRol(string nombreRol)
        {
            List<clsRolBE> clsRolBEs = new List<clsRolBE>();
            clsRolBE oclsRolBE ;            
            using (SqlConnection conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from trnRol where NombreRol like'%"
                    + nombreRol + "%';", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oclsRolBE = new clsRolBE();
                        oclsRolBE.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                        oclsRolBE.NombreRol = reader["NombreRol"].ToString();
                        clsRolBEs.Add(oclsRolBE);
                    }
                }
            }
            return clsRolBEs;
        }
        public clsRolBE BuscarRolPorId(int IdRol)
        {            
            clsRolBE oclsRolBE = new clsRolBE();
            using (SqlConnection conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from trnRol where IdRol="
                    + IdRol.ToString() + ";", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        oclsRolBE.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                        oclsRolBE.NombreRol = reader["NombreRol"].ToString();                        
                    }
                }
            }
            return oclsRolBE;
        }
        public int AgregarRol(string nombreRol)
        {
            using (SqlConnection conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();

                // Verifica si el rol ya existe
                SqlCommand cmdSelect = new SqlCommand($"SELECT COUNT(*) FROM trnRol WHERE NombreRol = '{nombreRol}';", conn);
                int rolExistente = Convert.ToInt32(cmdSelect.ExecuteScalar());

                if (rolExistente > 0)
                {
                    // El rol ya existe, no se puede agregar de nuevo
                    return -1;
                }

                // Agrega el nuevo rol
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO trnRol (NombreRol) VALUES (@NombreRol);", conn);
                cmdInsert.Parameters.AddWithValue("@NombreRol", nombreRol);                

                return cmdInsert.ExecuteNonQuery(); // Retorna el número de filas afectadas (debería ser 1)
            }
        }
        public int ActualizarRol(int idRol, string nombreRol)
        {
            using (SqlConnection conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();

                // Verifica si el rol existe
                SqlCommand cmdSelect = new SqlCommand($"SELECT COUNT(*) FROM trnRol WHERE IdRol = @IdRol;", conn);
                cmdSelect.Parameters.AddWithValue("@IdRol", idRol);
                int rolExistente = Convert.ToInt32(cmdSelect.ExecuteScalar());

                if (rolExistente == 0)
                {
                    // El rol no existe, no se puede actualizar
                    return -1;
                }

                // Actualiza el rol
                SqlCommand cmdUpdate = new SqlCommand("UPDATE trnRol SET NombreRol = @NombreRol WHERE IdRol = @IdRol;", conn);
                cmdUpdate.Parameters.AddWithValue("@IdRol", idRol);
                cmdUpdate.Parameters.AddWithValue("@NombreRol", nombreRol);                

                return cmdUpdate.ExecuteNonQuery(); // Retorna el número de filas afectadas (debería ser 1)
            }
        }
    }
}
