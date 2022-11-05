using Microsoft.AspNetCore.Mvc;
using projectFront.Controllers;
using projectFront.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectFront
{
    public partial class AuthForm : Form
    {
        UsersController usersController = new UsersController();

        public AuthForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActionResult<Users> userResult = usersController.Get(textBox1.Text, textBox2.Text);
            
            if (userResult.Value != null)
            {
                Form menuForm = new mainMenu();
                menuForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Кажется вы ошиблись при вводе");
            
           

        }
    }
}
