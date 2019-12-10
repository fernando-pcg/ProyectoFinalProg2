using FinalProg2.GestionesAdministrador.GestionPrestamos;
using FinalProg2.GestionUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FinalProg2
{
    public partial class Admin : Form
    {
        
        
        GestionUsuarios.MenUsers MU = new GestionUsuarios.MenUsers();

        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestClientesForm GCL = new GestClientesForm();
            GCL.ShowDialog();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrestamosForm PF = new PrestamosForm();
            this.Hide();
            PF.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MU.Show();
        }
    }
}
