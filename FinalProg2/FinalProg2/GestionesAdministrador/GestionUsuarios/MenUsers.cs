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
using FinalProg2.GestionesAdministrador.GestionUsuarios;

namespace FinalProg2.GestionUsuarios
{
    public partial class MenUsers : Form
    {

        DatosLogin DL = new DatosLogin();
        EditUser EU = new EditUser();
        AddUser AU = new AddUser();
        int IDSel;
        public MenUsers()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void LlenarGrid()
        {
            try
            {
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                this.dataGridView1.MultiSelect = false;
                dataGridView1.DataSource = DL.LlenarGridU();
            }
            catch (Exception Error)
            {
                MessageBox.Show("Error: " + Error);

            }
        }

        private void btn_AddU_Click(object sender, EventArgs e)
        {
            AU.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EU.getID(IDSel);
            EU.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDSel = int.Parse(dataGridView1.CurrentCell.Value.ToString());
            }
            catch (Exception Error)
            {
                IDSel = 0;
                MessageBox.Show("Esta celda no tiene valor: " + Error);
            }
        }
    }
}
