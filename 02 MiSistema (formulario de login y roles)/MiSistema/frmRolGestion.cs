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
    public partial class frmRolGestion : Form
    {
        public frmRolGestion()
        {
            InitializeComponent();            
        }
        public clsRolBE oclsRolBE = new clsRolBE();
        void CargarDatos(int IdRol)
        {
            Rol rol = new Rol();
            oclsRolBE= rol.BuscarRolPorId(IdRol);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(oclsRolBE.IdRol==0) //nuevo registro
            {
                Rol rol = new Rol();
                rol.AgregarRol(txtNombreRol.Text);
                MessageBox.Show("Se realizo el registro correctamente");
                this.Close();
            }
            else
            {
                Rol rol = new Rol();
                rol.ActualizarRol(oclsRolBE.IdRol,txtNombreRol.Text);
                MessageBox.Show("Se actualizo el registro correctamente");
                this.Close();
            }
        }
    }
}
