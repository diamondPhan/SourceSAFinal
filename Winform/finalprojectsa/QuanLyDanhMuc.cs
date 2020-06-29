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
    public partial class QuanLyDanhMuc : Form
    {
        Thread th;
        public QuanLyDanhMuc()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            categearhost.CategoryService service = new categearhost.CategoryService();
            List<categearhost.Category> computers = service.GetAll().ToList();
            dataGridView1.DataSource = computers;
        }
        //detail
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells["ID_LoaiSanPham"].Value.ToString());
                categearhost.CategoryService service = new categearhost.CategoryService();
                categearhost.Category c = service.GetByID(id);
                if (c != null)
                {
                    textBox1.Text = c.ID_LoaiSanPham.ToString();
                    textBox2.Text = c.TenLoaiSanPham;
                    textBox3.Text = c.DonViTinh;
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ten = textBox2.Text.Trim();
            String donvi = textBox3.Text.Trim();
            categearhost.CategoryService service = new categearhost.CategoryService();
            categearhost.Category newComputer = new categearhost.Category() { ID_LoaiSanPham = 0, TenLoaiSanPham = ten, DonViTinh = donvi };
            bool result = service.AddNew(newComputer);
            if (result)
            {
                MessageBox.Show("Success!");
                List<categearhost.Category> computers = service.GetAll().ToList();
                dataGridView1.DataSource = computers;
            }
            else
            {
                MessageBox.Show("Fail!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Openbacktomenu);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Openbacktomenu()
        {
            Application.Run(new Form1());
        }
    }
}
