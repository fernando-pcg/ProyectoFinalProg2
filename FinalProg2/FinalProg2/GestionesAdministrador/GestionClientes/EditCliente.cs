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

namespace FinalProg2.GestionClientes
{
    public partial class EditCliente : Form
    {
        DatosLogin DL = new DatosLogin();
        int IDSel;
        public EditCliente()
        {
            InitializeComponent();
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

        public void getID(int Id)
        {
            IDSel = Id;
        }

        private void EditCliente_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> info = new List<string>();
                DatosLogin DL = new DatosLogin();
                info = DL.GetDataClient(IDSel);

                txt_NameE.Text = info[0];
                txt_LastE.Text = info[1];
                txt_DNIE.Text = info[2];
                dtp_DateE.Text = info[3];
                txt_Age.Text = info[4];
                txt_AddressE.Text = info[5];
                txt_TellE.Text = info[6];
                txt_CellE.Text = info[7];
            }
            catch (Exception Error)
            {
                MessageBox.Show("Ocurrio un error: " + Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            DL.Actualizar(txt_NameE.Text,txt_LastE.Text, txt_DNIE.Text, dtp_DateE.Text, int.Parse(txt_Age.Text), txt_AddressE.Text, Int64.Parse(txt_TellE.Text), Int64.Parse(txt_CellE.Text), IDSel);
            MessageBox.Show("Contacto Actualizado");
            }
            catch(Exception Error)
            {
                MessageBox.Show("Ocurrio un error: " + Error);
            }
        }
    }
}
