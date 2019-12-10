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

namespace FinalProg2
{
    public partial class LoginForm : Form
    {

        Login log = new Login();
        Cliente cl = new Cliente();
        
        DatosLogin Datalog = new DatosLogin();

        Cliente CF = new Cliente();
        Admin AF = new Admin();
        int Id;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        public void btn_Entrar_Click(object sender, EventArgs e)
        {


                if (txt_MailLog.Text == "" || txt_PassLog.Text == "")
                {
                    MessageBox.Show("Rellene todos los campos");
                }
                else
                {
                    string ClaveR;
                

                    log.Correo = txt_MailLog.Text;
                    log.Clave = txt_PassLog.Text;

                    ClaveR = Datalog.LoginRequest(log.Correo);

                    if(ClaveR == log.Clave)
                    {
                        int RolR;

                        RolR = Datalog.RolRequest(log.Correo);

                        if(RolR == 1)
                        {
                            this.Hide();
                            CF.Show();
                        }
                        else if(RolR == 2)
                        {
                            this.Hide();
                            AF.Show();
                        }
                        else
                        {
                            MessageBox.Show("Revise los datos, si el problema persiste cosulte google");   
                        }
                    }
                    else if(ClaveR == "Correo")
                    {
                        MessageBox.Show("Correo no encontrado");
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Incorrecta");
                    }



                }

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
