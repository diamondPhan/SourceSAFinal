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
    public partial class Form1 : Form
    {
        Thread th;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Openquanlyuser);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Openquanlyuser()
        {
            Application.Run(new QuanlyUser());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Openquanlydanhmuc);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Openquanlydanhmuc()
        {
            Application.Run(new QuanLyDanhMuc());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Openquanlysp);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Openquanlysp()
        {
            Application.Run(new QuanLySanPham());
        }
    }
}
