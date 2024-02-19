using MiSistema.Datos;
using MiSistema.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace MiSistema.Negocios
{
    public class Usuario
    {
        public static string CreatePasswordHash(string password, string salt)
        {
            // Concatenate password and salt
            string combinedString = string.Concat(password, salt);

            // Create a SHA1 hash
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(combinedString));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Convert to hexadecimal
                }

                return sb.ToString();
            }
        }
        public clsUsuarioBE Autenticar(string nombreusuario, string clave)
        {
            string cPasswordhash = string.Empty;
            clsUsuarioDA oclsUsuarioDA = new clsUsuarioDA();
            clsUsuarioBE oclsUsuarioBE = new clsUsuarioBE();
            oclsUsuarioBE = oclsUsuarioDA.GetPorNombreUsuario(nombreusuario);
            if (oclsUsuarioBE.IdUsuario == 0) //si el id es igual a cero el nombre de usuario no existe
            { 
                return oclsUsuarioBE;
            }
            else
            {
                cPasswordhash = CreatePasswordHash(clave, oclsUsuarioBE.Salt.Trim());
                if ( cPasswordhash == oclsUsuarioBE.Clave)//preguntara si existe usuario y si la clave/usuario estan bien
                {
                    return oclsUsuarioBE; //el usuario y la contraseña son validos
                }
                else
                {
                    //"El usuario y/o contraseña no son validos. Verifique e intente nuevamente";
                    oclsUsuarioBE.IdUsuario = -1;
                }
            }
            return oclsUsuarioBE;
        }
    }
}
