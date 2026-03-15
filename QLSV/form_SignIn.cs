using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_signIn.BorderRadius = 20;
            panel_signIn.BorderSize = 2;
            panel_signIn.BorderColor = Color.FromArgb(100, 100, 100);
            panel_signIn.BackColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Giả lập đăng nhập thành công
            this.Hide();
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void link_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Sign_up signUpForm = new Sign_up();
            signUpForm.ShowDialog();
            this.Close();
        }
    }
}
