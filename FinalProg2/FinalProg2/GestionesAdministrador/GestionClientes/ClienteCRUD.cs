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

namespace FinalProg2.GestionClientes
{
    public partial class ClienteCRUD : Form
    {
        DatosLogin DL = new DatosLogin();
        EditCliente ED = new EditCliente();
        int IDSel;
        public ClienteCRUD()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void ClienteCRUD_Load(object sender, EventArgs e)
        {

        }

        public void FillDataCliente(int Id)
        {
            List<string> info = new List<string>();
            DatosLogin DL = new DatosLogin();
            IDSel = Id;
            info = DL.GetDataClient(Id);

            lbl_NameD.Text = info[0];
            lbl_LastD.Text = info[1];
            lbl_DNI.Text = info[2];
            lbl_DateD.Text = info[3];
            lbl_Age.Text = info[4];
            lbl_Address.Text = info[5];
            lbl_Tel.Text = info[6];
            lbl_Cell.Text = info[7];

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ED.Show();
            ED.getID(IDSel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DL.Borrar(IDSel);
            MessageBox.Show("Contacto con el Id: " + IDSel + "Borrado");
        }
    }
}
