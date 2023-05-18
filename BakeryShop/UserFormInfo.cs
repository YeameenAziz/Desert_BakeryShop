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

namespace BakeryShop
{
    public partial class UserFormInfo : Form
    {
        public UserFormInfo()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-I1UD0BH;Initial Catalog=loginform;Integrated Security=True");    
        void populate()
        {
            Con.Open();
            string query = "Select * from UserTb1";
            SqlDataAdapter ad = new SqlDataAdapter(query,Con);
            SqlCommandBuilder build = new SqlCommandBuilder(ad);
            var da = new DataSet();
            ad.Fill(da);
            UserFI.DataSource= da.Tables[0];
            Con.Close();

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserInfo uinfo = new UserInfo();
            uinfo.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ItemInfo item = new ItemInfo();
            item.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login= new Form1();
            login.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
          // Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "insert into UserTb1 values(' " + UnameTb.Text + " ', ' " + UphoneTb.Text + "', '" + UaddressTb.Text + " ')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Succesfully Created");
            Con.Close();
            populate();
        }

        private void UserFormInfo_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void UserFI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UserFI.SelectedRows[0].Cells[0].Value.ToString();
            UphoneTb.Text = UserFI.SelectedRows[0].Cells[1].Value.ToString();
            UaddressTb.Text = UserFI.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-I1UD0BH;Initial Catalog=loginform;Integrated Security=True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM UserTb1 WHERE Uphone = @Uphone", Con);
            cmd.Parameters.AddWithValue("@UphoneTb",int.Parse(UphoneTb.Text));
            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Succesfully Deleted");
            populate();

           

            /*if (UphoneTb.Text == "")
            {

                  Con.Open();
                  string query = "delete from UserTb1 where Uphone = '" + UphoneTb.Text + "'"; 
                  SqlCommand cmd = new SqlCommand(query, Con);
                  cmd.ExecuteNonQuery();
                  MessageBox.Show("The User is Succesfully Deleted");
                  Con.Close();
                  populate();
                  
                MessageBox.Show("Select The User to be Deleted");
            }
            else
            {
                 Con.Open();
                string query = "DELETE FROM UserTb1 WHERE Uphone = @Uphone";
                SqlCommand cmd = new SqlCommand(query, Con);
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("The User is Succesfully Deleted");
                 Con.Close();
                 populate();
                
            } */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UphoneTb.Text == "" || UaddressTb.Text == "" || UnameTb.Text == "" )
            {
                MessageBox.Show("Fill All The Tables");
            }
            else
            {
                Con.Open();
                string query = "Update UserTb1 Set Username='" + UnameTb.Text + "',UuserAddress='" + UaddressTb.Text + "' where UserPhone ='"+UphoneTb.Text + "'";
                SqlCommand cmd =new SqlCommand(query, Con); 
                cmd.ExecuteNonQuery();  
                Con.Close();
                populate();

            }
                    
         }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void UnameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
