using MiSistema.Entidades;
using MiSistema.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiSistema
{
    public partial class frmAutenticar : Form
    {
        public frmAutenticar()
        {
            InitializeComponent();
        }

        private void btnAutenticar_Click(object sender, EventArgs e)
        {
            Usuario oclsUsuario = new Usuario();
            clsUsuarioBE oclsUsuarioBE = oclsUsuario.Autenticar(txtUsuario.Text, txtClave.Text);
            if (oclsUsuarioBE.IdUsuario > 0)
            {
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("credenciales invalidas");
            }
        }
    }
}
