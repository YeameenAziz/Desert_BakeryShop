using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BakeryShop
{
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-I1UD0BH;Initial Catalog=loginform;Integrated Security=True");
        
          void populate()
        {
            Con.Open();
            string query = "Select * from OrdersTb1";
            SqlDataAdapter ad = new SqlDataAdapter(query,Con);
            SqlCommandBuilder build = new SqlCommandBuilder(ad);
            var da = new DataSet();
            ad.Fill(da);
            ItemsUI.DataSource= da.Tables[0];
            Con.Close();

        }
         
         
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemInfo Item = new ItemInfo();
            Item.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserFormInfo user = new UserFormInfo();
            user.Show();    
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      
        int num = 0;
        int price, Qty, total;
        string item,Cat;

        private void ItemsUI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Name = ItemsUI.SelectedRows[0].Cells[1].Value.ToString();
            Cat = ItemsUI.SelectedRows[0].Cells[2].Value.ToString();
            price = Convert.ToInt32(ItemsUI.SelectedRows[0].Cells[3].Value.ToString());
            flag = 1;
        } 
        DataTable table = new DataTable();
        int flag = 0;

        private void UserInfo_Load(object sender, EventArgs e)
        {
          populate();
          table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Unit Price", typeof(int));
            table.Columns.Add("Total",typeof(int));
            OrderUI.DataSource = table;
        }
        
        private void OrderUI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(QtyTb.Text == "")
            {
                MessageBox.Show("What is the Quantity of the item");
            }
            else if(flag== 0) 
            {

                MessageBox.Show("Select the Product to be ordered");
            
            }
            else 
            {

                num = num+ 1;
                total = price * Convert.ToInt32(QtyTb.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
