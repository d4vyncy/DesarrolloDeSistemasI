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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            frmRol frmRol = new frmRol();
            frmRol.ShowDialog();
        }
    }
}
