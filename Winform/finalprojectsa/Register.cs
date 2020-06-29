using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalprojectsa
{
    public partial class Register : Form
    {
        Thread th;
        accountgearhost.accountService service = new accountgearhost.accountService();
        public Register()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password do not match");
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Username and Password can't be empty");
            }
            else
            {

                string username = textBox1.Text.Trim();
                string password = textBox2.Text.Trim();
                string confirmpass = textBox3.Text.Trim();

                accountgearhost.account newAcc = new accountgearhost.account() { username = username, password = password };
                bool result = service.AddAcc(newAcc);
                if (result)
                {
                    MessageBox.Show("Register Successful");
                    this.Close();
                    th = new Thread(opennewform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else
                {
                    MessageBox.Show("Username or Email already exist");
                }
            }
        }
        private void opennewform()
        {
            Application.Run(new Login());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Openprevform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Openprevform()
        {
            Application.Run(new Login());
        }
    }
}
