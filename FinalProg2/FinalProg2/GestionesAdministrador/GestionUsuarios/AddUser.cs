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
    public partial class AddUser : Form
    {
        DatosLogin DL = new DatosLogin();
        Users U = new Users();
        
        public AddUser()
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

        private void AddUser_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            DL.GuardarU(U.Name,U.Mail,U.Pass,U.Mode);
        }

        private void txt_LastA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
