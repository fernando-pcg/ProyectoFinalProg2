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
using Logica;

namespace FinalProg2
{
    public partial class GestClientesForm : Form
    {
        DatosLogin DL = new DatosLogin();
        Login log = new Login();
        int IDSel;
        public GestClientesForm()
        {
            InitializeComponent();
        }

        private void GestClientesForm_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {

            LlenarGridBC();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        public void LlenarGrid()
        {
            try {
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                this.dataGridView1.MultiSelect = false;
                dataGridView1.DataSource = DL.LlenarGrid();
            }
            catch (Exception Error)
            {
                MessageBox.Show("Error: " + Error);

            }
        }
        public void LlenarGridBC()
        {
            
            dataGridView1.DataSource = DL.Buscar(int.Parse(textBox1.Text)); ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionClientes.AddCliente AC = new GestionClientes.AddCliente();
            AC.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns["IdCliente"].SortMode = DataGridViewColumnSortMode.NotSortable;
            LlenarGrid();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try { 
            IDSel = int.Parse(dataGridView1.CurrentCell.Value.ToString());
            }
            catch (Exception Error)
            {
                IDSel = 0;
                MessageBox.Show("Esta celda no tiene valor: " + Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionClientes.ClienteCRUD CR = new GestionClientes.ClienteCRUD();
            CR.Show();
            CR.FillDataCliente(IDSel);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
