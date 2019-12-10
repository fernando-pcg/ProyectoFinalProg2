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

namespace FinalProg2.GestionesAdministrador.GestionUsuarios
{
    public partial class EditUser : Form
    {
        DatosLogin DL = new DatosLogin();
        Users U = new Users();
        int IDSel;
        public EditUser()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
        private void EditUser_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> info = new List<string>();
                DatosLogin DL = new DatosLogin();
                info = DL.GetDataClient(IDSel);

                txt_NameA.Text = info[0];
                txt_LastA.Text = info[1];
                txt_DNIA.Text = info[2];
                comboBox1.SelectedIndex = int.Parse(info[3]);

            }
            catch (Exception Error)
            {
                MessageBox.Show("Ocurrio un error: " + Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DL.BorrarU(IDSel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            string SelectedMode;
            U.Name = txt_NameA.Text;
            U.Mail = txt_LastA.Text;
            U.Pass = txt_DNIA.Text;

            SelectedMode = comboBox1.SelectedIndex.ToString();

            switch (SelectedMode)
            {
                case "0":
                    U.Mode = "Activo";
                    break;
                case "1":
                    U.Mode = "Inactivo";
                    break;
            }

            DL.ActualizarU(U.Name, U.Mail, U.Pass, U.Mode,IDSel);
            }
            catch(Exception Error)
            {
                MessageBox.Show("Ocurrio un error: " + Error);
            }
        }
    }
}
