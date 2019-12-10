using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace FinalProg2.GestionesAdministrador.GestionPrestamos
{
    public partial class PrestamosForm : Form
    {
        LoginForm LG = new LoginForm();
        DatosLogin DL = new DatosLogin();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LlenarGrid()
        {
            try
            {
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                this.dataGridView1.MultiSelect = false;
                dataGridView1.DataSource = DL.LlenarGridP();
            }
            catch (Exception Error)
            {
                MessageBox.Show("Error: " + Error);

            }
        }

        private void PrestamosForm_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}
