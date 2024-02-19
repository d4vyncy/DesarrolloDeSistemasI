using MiSistema.Datos;
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
    public partial class frmRol : Form
    {
        public frmRol()
        {
            InitializeComponent();
            dtgvDatos.AutoGenerateColumns = false;
            llenarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmRolGestion frmRolGestion = new frmRolGestion();  
            frmRolGestion.ShowDialog();
            llenarDatos();
        }
        void llenarDatos()
        {
            Rol oRol = new Rol();            
            dtgvDatos.DataSource= oRol.BuscarRol(txtNombreRol.Text);
            
        }
    }
}
