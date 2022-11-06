using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
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
using Application = System.Windows.Forms.Application;

namespace projectFront
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }
        OrdersController ordersController = new OrdersController();
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

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form thisForm = Application.OpenForms[1];
            thisForm.Show();
        }
        private void getInfo_Click(object sender, EventArgs e)
        {
            ActionResult<List<Orders>> ordersResult = ordersController.Get();
            dataGridView1.DataSource = ordersResult.Value;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            if (checkMistakesID() == true)
            {

                ActionResult<Orders> ordersResult = ordersController.Get(textBox1.Text);

                List<Orders> listRes = new List<Orders>();
                listRes.Add(ordersResult.Value);
                dataGridView2.DataSource = listRes;
            }
        }

        private void getInfoId_Click_1(object sender, EventArgs e)
        {
            if (checkMistakesID() == true)
            {

                ActionResult<Orders> ordersResult = ordersController.Get(textBox1.Text);

                List<Orders> listRes = new List<Orders>();
                listRes.Add(ordersResult.Value);
                dataGridView1.DataSource = listRes;
            }
        }

        private void deleteInfoId_Click_1(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {
                ActionResult result2 = null;
                ActionResult result = ordersController.Delete(textBox1.Text);
                var result3 = (OkObjectResult)result; //Код запроса
                if (result != result3.Value)
                { MessageBox.Show("Объект удален"); }

            }
        }

        private void postInfo_Click_1(object sender, EventArgs e)
        {
            //Cleaner();
            List<Orders> postList = new List<Orders>();
            Orders orders = new Orders();

            orders.Client = "";
            orders.DateOrd = new DateTime();
            orders.Cook = "";
            orders.Cake = "";
            orders.Price = 0;

            postList.Add(orders);
            dataGridView2.DataSource = postList;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Orders orders = new Orders();
            orders.Id = textBox1.Text;
            orders.Client = (string)dataGridView2[1, 0].Value;
            orders.DateOrd = (DateTime)dataGridView2[2, 0].Value;
            orders.Cook = (string)dataGridView2[3, 0].Value;
            orders.Cake = (string)dataGridView2[4, 0].Value;
            orders.Price = (int)dataGridView2[5, 0].Value;


            ordersController.Put(textBox1.Text, orders);
            Cleaner();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Orders orders = new Orders();
            orders.Id = "";
            orders.Client = (string)dataGridView2[1, 0].Value;
            orders.DateOrd = (DateTime)dataGridView2[2, 0].Value;
            orders.Cook = (string)dataGridView2[3, 0].Value;
            orders.Cake = (string)dataGridView2[4, 0].Value;
            orders.Price = (int)dataGridView2[5, 0].Value;

            ordersController.Post(orders);
            //Cleaner();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form menuForm = new mainMenu();
            menuForm.Show();
            this.Close();
        }
    }
}
