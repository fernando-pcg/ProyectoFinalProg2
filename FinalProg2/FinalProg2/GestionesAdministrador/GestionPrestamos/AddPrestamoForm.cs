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
namespace FinalProg2.GestionesAdministrador.GestionPrestamos
{
    public partial class AddPrestamoForm : Form
    {
        Prestamo CL = new Prestamo();
        DatosLogin DL = new DatosLogin();
        public AddPrestamoForm()
        {
            InitializeComponent();
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal interes;

                CL.Capital = decimal.Parse(txt_Capital.Text);
                CL.Interes = decimal.Parse(txt_Interes.Text);
                CL.Tiempo = txt_Tiempo.Text;
                CL.Cuotas = int.Parse(txt_Cuotas.Text);
                CL.Fecha = txt_Fecha.Text;
                CL.Pagos = CL.Capital / CL.Cuotas;
                interes = CL.Capital * CL.Interes / 100;
                CL.Deudas = decimal.Parse(txt_Capital.Text) + interes;

                MessageBox.Show("Cliente Añadido");

                Limpiar();

                DL.GuardarP( CL.Interes,CL.Capital, CL.Tiempo, CL.Fecha, CL.Cuotas, CL.Pagos, CL.Deudas);
            }
            catch (Exception Error)
            {
                MessageBox.Show("A ocurrido un error: " + Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DL.BorrarP(1);
        }
    }
}
