using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;

namespace SteamLabel
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UBC4JA8\\SQLEXPRESS;Initial Catalog=SteamLabel;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            panel2.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox3.Text;
            string mail = textBox2.Text;
            string email = @"^[a-zA-Z0-9._%+-]+@(?:\bmail\b|\bgmail\b|\bhotmail\b|\byahoo\b|\boutlook\b|\b[a-zA-Z0-9.-]+\.com\b)$";
            Regex regex = new Regex(email);
            if (regex.IsMatch(textBox2.Text))
            {
                con.Open();
                if (textBox3.Text == textBox4.Text && textBox3.Text != null)
                {
                    string message = "You created your account succsefully ";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons);

                }
                else
                {
                    string message = "Your password does not coincide";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                    MessageBox.Show(message, title, buttons);
                }
                SqlCommand insertcmd = new SqlCommand("INSERT INTO Registration (Login,Mail,Password) values (@Login , @Mail , @Password)", con);
                insertcmd.Parameters.AddWithValue("@Login" , login);
                insertcmd.Parameters.AddWithValue("Mail" ,mail);
                insertcmd.Parameters.AddWithValue("@Password" , password);
                insertcmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                string message = "Invalid mail type";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Show();
           panel2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string login = textBox8.Text;
            string password = textBox6.Text;
            try
            {
                String query = "SELECT *FROM Registration WHERE login ='" + textBox8.Text + "' AND PASSWORD = '" + textBox6.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dataT = new DataTable();
                sda.Fill(dataT);
                if (dataT.Rows.Count > 0)
                {
                    string message = "Success";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons);
                }
                else
                {
                    string message = "Login or Password wrong";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                    MessageBox.Show(message, title, buttons);
                }

            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
