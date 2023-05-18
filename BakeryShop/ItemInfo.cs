using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace BakeryShop
{
    public partial class ItemInfo : Form
    {
        public ItemInfo()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-I1UD0BH;Initial Catalog=loginform;Integrated Security=True");
        
         void populate()
        {
            Con.Open();
            string query = "Select * from ItemTb1";
            SqlDataAdapter ad = new SqlDataAdapter(query,Con);
            SqlCommandBuilder build = new SqlCommandBuilder(ad);
            var da = new DataSet();
            ad.Fill(da);
            ItemsUI.DataSource= da.Tables[0];
            Con.Close();

        }
         
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserInfo order= new UserInfo(); 
            order.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           // Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(ItemNameTb.Text == "" || ItemNumTb.Text == "" || ItemPriceTb.Text == "")

           {
               MessageBox.Show("Fill up the Data");      
               
            }
           
            else
           {

                Con.Open();
                //string query = "insert into ItemTb1 values(' " + ItemNumTb.Text + " ', ' " + ItemNameTb.Text + "', '" + ItemCatTb.SelectedItem.ToString() + "','" + ItemPriceTb.Text + ")";
                String query = "INSERT INTO ItemTb1 VALUES ('" + ItemNumTb.Text + "', '" + ItemNameTb.Text + "', '" + ItemCatTb.SelectedItem.ToString() + "', '" + ItemPriceTb.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Succesfully Created");
                Con.Close();
                populate();











                /*Con.Open();
                string query = "insert into ItemTb1 values(" + ItemNumTb.Text + " ' , ' " + ItemNameTb.Text + "','" + ItemCatTb.SelectedItem.ToString() + "','" + ItemPriceTb.Text + ")";
              /*SqlCommand cmd = new SqlCommand(query, Con);
               cmd.ExecuteNonQuery();
                MessageBox.Show("Item Succesfully Created");
                Con.Close();*/
                populate();
            }
        }

        private void ItemInfo_Load(object sender, EventArgs e)
        {
            populate(); 
        }

        private void ItemPriceTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void ItemsUI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

             ItemNumTb.Text = ItemsUI.SelectedRows[0].Cells[0].Value.ToString();
            ItemNameTb.Text = ItemsUI.SelectedRows[0].Cells[1].Value.ToString();
            ItemCatTb.Text = ItemsUI.SelectedRows[0].Cells[2].Value.ToString();
            ItemPriceTb.Text = ItemsUI.SelectedRows[0].Cells[3].Value.ToString(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-I1UD0BH;Initial Catalog=loginform;Integrated Security=True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("Delete ItemTb1 where ItemNum =@ItemNumTb", Con);
            cmd.Parameters.AddWithValue("@ItemNumTb", int.Parse(@ItemNumTb.Text));
            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Succesfully Deleted");
            populate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
              if (ItemNameTb.Text == "" || ItemNumTb.Text == "" || ItemPriceTb.Text == "")
              {
                  MessageBox.Show("Fill All The Tables");
              }
              else
              {
                  Con.Open();
                // string query = "Update ItemTb1 Set Itename='" + ItemNameTb.Text + "',ItemCat='" + ItemCatTb.SelectedItem.ToString() + "' where ItemPrice ='" + ItemPriceTb.Text + "";
                 String query = "INSERT INTO ItemTb1 VALUES ('" + ItemNumTb.Text + "', '" + ItemNameTb.Text + "', '" + ItemCatTb.SelectedItem.ToString() + "', '" + ItemPriceTb.Text + "')";
                  SqlCommand cmd = new SqlCommand(query, Con);
                  cmd.ExecuteNonQuery();
                  MessageBox.Show("Item Succesfully Updated");
                  Con.Close();
                  populate();

              } 
        }

        private void ItemCatTb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
