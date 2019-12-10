using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProg2.GestionesAdministrador.GestionPrestamos
{
    public partial class PrestamosForm : Form
    {
        LoginForm LG = new LoginForm();
        public PrestamosForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LG.ShowDialog();
        }

        private void btn_AddU_Click(object sender, EventArgs e)
        {
            AddPrestamoForm APF = new AddPrestamoForm();

            APF.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditPrestamoForm PC = new EditPrestamoForm();
            PC.Show();
        }
    }
}
