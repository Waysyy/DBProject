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
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
        }
        public bool checkMistakesID()
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Кажется вы забыли заполнить поле ID");
                return false;
            }
            else
                return true;
        }

        public void Cleaner()
        {
            textBox1.Text = null;
            dataGridView2 = null;
        }

        ClientsController clientsController = new ClientsController();
        private void getInfo_Click(object sender, EventArgs e)
        {
            ActionResult<List<Clients>> clientsResult = clientsController.Get();
            dataGridView1.DataSource = clientsResult.Value;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Form menuForm = new mainMenu();
            menuForm.Show();
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form thisForm = Application.OpenForms[1];
            thisForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Clients clients = new Clients();
            clients.Id = textBox1.Text;
            clients.Name = (string)dataGridView2[1, 0].Value;
            clients.Lastname = (string)dataGridView2[2, 0].Value;
           

            clientsController.Put(textBox1.Text, clients);
            Cleaner();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {

                ActionResult<Clients> clientsResult = clientsController.Get(textBox1.Text);

                List<Clients> listRes = new List<Clients>();
                listRes.Add(clientsResult.Value);
                dataGridView2.DataSource = listRes;
            }

        }

        private void getInfoId_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {

                ActionResult<Clients> clientsResult = clientsController.Get(textBox1.Text);

                List<Clients> listRes = new List<Clients>();
                listRes.Add(clientsResult.Value);
                dataGridView1.DataSource = listRes;
            }
        }

        private void deleteInfoId_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {
                ActionResult result2 = null;
                ActionResult result = clientsController.Delete(textBox1.Text);
                var result3 = (OkObjectResult)result; //Код запроса
                if (result != result3.Value)
                { MessageBox.Show("Объект удален"); }

            }
        }

        private void postInfo_Click(object sender, EventArgs e)
        {
            //Cleaner();
            List<Clients> postList = new List<Clients>();
            Clients clients = new Clients();

            clients.Name = "";
            clients.Lastname = "";

            postList.Add(clients);
            dataGridView2.DataSource = postList;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Clients clients = new Clients();
            clients.Id = "";
            clients.Name = (string)dataGridView2[1, 0].Value;
            clients.Lastname = (string)dataGridView2[2, 0].Value;

            clientsController.Post(clients);
            Cleaner();
        }

    }
}
