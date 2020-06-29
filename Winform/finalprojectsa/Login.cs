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
    public partial class Login : Form
    {
        Thread th;
        accountgearhost.accountService service = new accountgearhost.accountService();
        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            accountgearhost.account log = new accountgearhost.account() { username = username, password = password };
            bool result = service.Login(log.username, log.password);
            if (result)
            {
                this.Close();
                th = new Thread(Openmainform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Username or password incorrect");
            }
        }
        private void Openmainform()
        {
            Application.Run(new Form1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Opennewform()
        {
            Application.Run(new Register());
        }
    }
}
