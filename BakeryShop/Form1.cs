using System.Data;
using System.Data.SqlClient;

namespace BakeryShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTypeUsername_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtTypeUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTypeUsername.Text == "Type Username")
            {
                txtTypeUsername.Clear();
            }
        }

        private void txtTypePassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTypePassword.Text == "Type Password")
            {
                txtTypePassword.Clear();
            }
        }

        private void txtTypeUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserInfo uinfo = new UserInfo();
            uinfo.Show();
            this.Hide();

            if (txtTypeUsername.Text=="")
            {
                MessageBox.Show("Enter the username");
            }
            else if (txtTypePassword.Text=="")
            {
                MessageBox.Show("Enter the Password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-I1UD0BH;Initial Catalog=loginform;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("select * from Table_1 where username = @username and password =@password", con);
                    cmd.Parameters.AddWithValue("@username", txtTypeUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtTypePassword.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    if(dt.Rows.Count > 0) 
                    {
                        MessageBox.Show("Login Succesfull");

                    }
                    else 
                    {
                        MessageBox.Show("Username or password is Invalid ");
                    }
                }
                catch (Exception ex)
                { 
                  MessageBox.Show(""+ ex);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BakeryMenu guest = new BakeryMenu();
            guest.Show();

            /*guest = new Thread(guest);
            this.SetBakeryMenu(guest = new Thread(BakeryMenu.STA);
            this.Start();
            this.Close();
        }
        private void OpenNewForm()
        {
            Application.Run(new Form1());
        }*/
        }
    }
}
