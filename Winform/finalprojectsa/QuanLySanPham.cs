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
    public partial class QuanLySanPham : Form
    {
        Thread th;
        public QuanLySanPham()
        {
            InitializeComponent();
        }
        //search
        private void button1_Click(object sender, EventArgs e)
        {
            String keyword = textBox1.Text.Trim();
            gearhost.ProductService service = new gearhost.ProductService();
            List<gearhost.Product> computers = service.Search(keyword).ToList();
            dataGridView1.DataSource = computers;
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            gearhost.ProductService service = new gearhost.ProductService();
            List<gearhost.Product> computers = service.GetAll().ToList();
            dataGridView1.DataSource = computers;
        }
        //add
        private void button2_Click(object sender, EventArgs e)
        {
            String name = textBox3.Text.Trim();
            int quanlity = int.Parse(textBox4.Text.Trim());
            int categorybyid = int.Parse(textBox5.Text.Trim());
            int price = int.Parse(textBox6.Text.Trim());
            String detail =textBox7.Text.Trim();
            String image = textBox8.Text.Trim();
            int sale = int.Parse(textBox9.Text.Trim());
            gearhost.ProductService service = new gearhost.ProductService();
            gearhost.Product newComputer = new gearhost.Product() { ProductID = 0, ProductName = name, Quanlity = quanlity , CategoryByID = categorybyid, Price = price, Detail = detail, Imange = image, Sale=sale };
            bool result = service.AddNew(newComputer);
            if (result)
            {
                MessageBox.Show("Success!");
                List<gearhost.Product> computers = service.GetAll().ToList();
                dataGridView1.DataSource = computers;
            }
            else
            {
                MessageBox.Show("Fail!");
            }
        }
        //get detail
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells["ProductID"].Value.ToString());
                gearhost.ProductService service = new gearhost.ProductService();
                gearhost.Product c = service.GetByID(id);
                if (c != null)
                {
                    textBox2.Text = c.ProductID.ToString();
                    textBox3.Text = c.ProductName;
                    textBox4.Text = c.Quanlity.ToString();
                    textBox5.Text = c.CategoryByID.ToString();
                    textBox6.Text = c.Price.ToString();
                    textBox7.Text = c.Detail;
                    textBox8.Text = c.Imange;
                    textBox9.Text = c.Sale.ToString();
                }
            }
        }
        //update
        private void button3_Click(object sender, EventArgs e)
        {
            gearhost.ProductService service = new gearhost.ProductService();
            gearhost.Product newcomp = new gearhost.Product()
            {
                ProductID = int.Parse(textBox2.Text.Trim()),
                ProductName = textBox3.Text.Trim(),
                Quanlity = int.Parse(textBox4.Text.Trim()),
                CategoryByID = int.Parse(textBox5.Text.Trim()),
                Price = int.Parse(textBox6.Text.Trim()),
                Detail = textBox7.Text.Trim(),
                Imange = textBox8.Text.Trim(),
                Sale = int.Parse(textBox9.Text.Trim())
            };


            bool result = service.Update(newcomp);
            if (result)
            {
                MessageBox.Show("Success!");
                List<gearhost.Product> computers = service.GetAll().ToList();
                dataGridView1.DataSource = computers;
            }
            else
            {
                MessageBox.Show("Fail!");
            }
        }
        //delate
        private void button4_Click(object sender, EventArgs e)
        {
            gearhost.ProductService service = new gearhost.ProductService();
            int id = int.Parse(textBox2.Text.Trim());
            gearhost.Product c = service.DeleteByID(id);
            if (MessageBox.Show("Bạn có chắc muốn xóa không ?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (c == null)
                {
                    MessageBox.Show("Success!");
                    List<gearhost.Product> computers = service.GetAll().ToList();
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
