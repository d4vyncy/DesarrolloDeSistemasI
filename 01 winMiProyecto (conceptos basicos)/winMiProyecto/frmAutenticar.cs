using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winMiProyecto.Datos;
using winMiProyecto.Entidades;

namespace winMiProyecto
{
    public partial class frmAutenticar : Form
    {
        public frmAutenticar()
        {
            InitializeComponent();
            UsuarioDA usuarioDA = new UsuarioDA();
           List<Usuario> lUsuario= usuarioDA.GetList();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioDA usuarioDA = new UsuarioDA();
            usuarioDA.GetListPrueba();
            Usuario usuario = usuarioDA.ValidaLogin(txtUsuario.Text, txtContrasenia.Text);
            if (usuario.IdUsuario > 0)
            {
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else
            {

                MessageBox.Show("Credenciales incorrectas");
            }
        }
    }
}
