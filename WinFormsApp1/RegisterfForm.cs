using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class RegisterfForm : Form
    {
        public RegisterfForm()
        {
            InitializeComponent();
            userNameField.Text = "Enter Name";
            userNameField.ForeColor = Color.Gray;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loginFiled_TextChanged(object sender, EventArgs e)
        {
            loginFiled.ForeColor = Color.Black;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            lastPoint = new Point(e.X, e.Y);

        }

        private void userNameField_Enter(object sender, EventArgs e)

        {
            userNameField.ForeColor = Color.Black;
            {
                if (userNameField.Text == "Enter Name")
                {
                    userNameField.Text = "";
                }
            }
        }
        private void userSurnameField_Enter(object sender, EventArgs e)
        {
            userSurnameField.ForeColor = Color.Black;
            {
                if (userSurnameField.Text == "Enter Surname")
                {
                    userSurnameField.Text = "";
                }
            }
        }
        private void loginFiled_Enter(object sender, EventArgs e)
        {
            loginFiled.ForeColor = Color.Black;
            {
                if (loginFiled.Text == "Enter login")
                {
                    loginFiled.Text = "";
                }
            }
        }
        private void passField_Enter(object sender, EventArgs e)
        {
            {
                if (passField.Text == "Enter pass")
                {
                    passField.Text = "";
                }
            }
        }
        private void userNameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void userSurnameField_TextChanged(object sender, EventArgs e)
        {

        }
        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Enter Name";
                userNameField.ForeColor = Color.Gray;
            }
        }

        private void loginFiled_Leave(object sender, EventArgs e)
        {           
            if (loginFiled.Text == "")
            {
                loginFiled.Text = "Enter login";
                loginFiled.ForeColor = Color.Gray;
            }
        }
        private void passField_Leave(object sender, EventArgs e)
        {           
            if (passField.Text == "")
            {
                passField.Text = "Enter pass";
                passField.ForeColor = Color.Gray;
            }           
        }
        private void userSurnameField_Leave(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "")
            {
                userSurnameField.Text = "Enter Surname";
                userSurnameField.ForeColor = Color.Gray;
            }
        }

        Point Lastpoint;

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Lastpoint = new Point(e.X, e.Y);
        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                MessageBox.Show("Enter name");
                return;
            }
        
            if (userSurnameField.Text == "")
            {
                MessageBox.Show("Enter surname");
                return;
            }

            if (loginFiled.Text == "")
            {
                MessageBox.Show("Enter login");
                return;
            }

            if (passField.Text == "")
            {
                MessageBox.Show("Enter pass");
                return;
            }

            if (isUserExists())
                return;
       
            Class1 db = new Class1();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `Name`, `Surname`) VALUES (@login, @pass, @Name, @Surname)", db.GetConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginFiled.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = userSurnameField.Text;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = userNameField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт был создан");
            else
                MessageBox.Show("Аккаунт не был создан");

            db.closeConnection();
        }

        private void passField_TextChanged(object sender, EventArgs e)
        {
            
        }



        public Boolean isUserExists()

        {
            Class1 db = new Class1();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL", db.GetConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginFiled.Text;
         

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Login already exists, try another");
                return true;
            }
            else
                return false;
        }
        private void loginFiled_MouseDown(object sender, MouseEventArgs e)
        {
         
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            loging_form logingForm = new loging_form();
            logingForm.Show();
        }
    }
}
