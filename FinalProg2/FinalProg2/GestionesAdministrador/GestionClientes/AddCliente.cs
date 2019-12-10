using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Datos;

namespace FinalProg2.GestionClientes
{
    public partial class AddCliente : Form
    {

        public AddCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            Cliente CL = new Cliente();
            DatosLogin DL = new DatosLogin();
            CL.Name = txt_NameA.Text;
            CL.LastN = txt_LastA.Text;
            CL.DNI = txt_DNIA.Text;
            CL.Date = dtp_DateA.Text;
            CL.Age = int.Parse(txt_Age.Text);
            CL.Address = txt_AddressA.Text;
            CL.Tel = Int64.Parse(txt_TellA.Text);
            CL.Cel = Int64.Parse(txt_CellA.Text);

                MessageBox.Show("Cliente Añadido");

                Limpiar();

            DL.Guardar(CL.Name, CL.LastN, CL.DNI, CL.Date, CL.Age, CL.Address, CL.Tel, CL.Cel);
            }
            catch(Exception Error)
            {
                MessageBox.Show("A ocurrido un error: " + Error);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Boton de limpiar;
        public void Limpiar() // limpiara todos los textbox para poder volver a escribir
        {
            foreach (Control tool in Controls)
            {
                if (tool is TextBox)
                {
                    tool.Text = "";
                }
            }
        }
    }
}
