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
    public partial class QuanlyUser : Form
    {
        Thread th;
        public QuanlyUser()
        {
            InitializeComponent();
        }

        private void QuanlyUser_Load(object sender, EventArgs e)
        {
            usergearhost.UserService service = new usergearhost.UserService();
            List<usergearhost.Customer> computers = service.GetAll().ToList();
            dataGridView1.DataSource = computers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String keyword = textBox1.Text.Trim();
            usergearhost.UserService service = new usergearhost.UserService();
            List<usergearhost.Customer> computers = service.Search(keyword).ToList();
            dataGridView1.DataSource = computers;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells["ID_KhachHang"].Value.ToString());
                usergearhost.UserService service = new usergearhost.UserService();
                usergearhost.Customer c = service.GetByID(id);
                if (c != null)
                {
                    textBox2.Text = c.ID_KhachHang.ToString();
                    textBox3.Text = c.UserName;
                    textBox4.Text = c.Password;
                    textBox5.Text = c.TenKhachHang;
                    textBox6.Text = c.DiaChi;
                    textBox7.Text = c.SDT;
                    textBox8.Text = c.Email;
                   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String username = textBox3.Text.Trim();
            String password = textBox4.Text.Trim();
            String tenkhachhang = textBox5.Text.Trim();
            String diachi =textBox6.Text.Trim();
            String sdt = textBox7.Text.Trim();
            String email = textBox8.Text.Trim();
            usergearhost.UserService service = new usergearhost.UserService();
            usergearhost.Customer newComputer = new usergearhost.Customer() {  ID_KhachHang= 0, UserName = username, Password = password, TenKhachHang = tenkhachhang, DiaChi = diachi, SDT = sdt, Email = email};
            bool result = service.AddNew(newComputer);
            if (result)
            {
                MessageBox.Show("Success!");
                List<usergearhost.Customer> computers = service.GetAll().ToList();
                dataGridView1.DataSource = computers;
            }
            else
            {
                MessageBox.Show("Fail!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            usergearhost.UserService service = new usergearhost.UserService();
            usergearhost.Customer newcomp = new usergearhost.Customer()
            {
            ID_KhachHang = int.Parse(textBox2.Text.Trim()),
            UserName = textBox3.Text.Trim(),
            Password= textBox4.Text.Trim(),
            TenKhachHang = textBox5.Text.Trim(),
            DiaChi = textBox6.Text.Trim(),
            SDT = textBox7.Text.Trim(),
            Email = textBox8.Text.Trim()
        };


            bool result = service.Update(newcomp);
            if (result)
            {
                MessageBox.Show("Success!");
                List<usergearhost.Customer> computers = service.GetAll().ToList();
                dataGridView1.DataSource = computers;
            }
            else
            {
                MessageBox.Show("Fail!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            usergearhost.UserService service = new usergearhost.UserService();
            int id = int.Parse(textBox2.Text.Trim());
            usergearhost.Customer c = service.DeleteByID(id);
            if (MessageBox.Show("Bạn có chắc muốn xóa không ?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (c == null)
                {
                    MessageBox.Show("Success!");
                    List<usergearhost.Customer> computers = service.GetAll().ToList();
                    dataGridView1.DataSource = computers;
                }
                else
                    MessageBox.Show("Fail!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Openmenu);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Openmenu()
        {
            Application.Run(new Form1());
        }
    }
}
