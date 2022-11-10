using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using MongoDB.Bson;
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
using System.Web.Http.Results;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;

namespace projectFront
{
    public partial class CakesForm : Form
    {
        bool buttonChangeCheck = false;
        public bool checkMistakesID()
        {
            if(textBox1.Text == String.Empty)
            {
                MessageBox.Show("Кажется вы забыли заполнить поле ID");
                return false;
            }
            else
               return true;
        }
        public bool CheckDatagrid()
        {
            bool check = false;
            for (int j = 0; j < dataGridView2.RowCount; ++j)
            {
                for (int i = 1; i < dataGridView2.ColumnCount; ++i)
                {
                    if (Convert.ToString(dataGridView2[i, j].Value) == string.Empty || Convert.ToString(dataGridView2[i, j].Value) == " ")
                    {
                        check = false;
                        MessageBox.Show("Заполните все поля");
                        break;
                    }
                    else
                        check = true;
                }
            }
            return check;
        }

        public void Cleaner()
        {
            textBox1.Text = null;
            dataGridView2 = null;
        }

        CakesController cakesController = new CakesController();
        public CakesForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            
            ActionResult<List<Cakes>> cakesResult = cakesController.Get();
            dataGridView1.DataSource = cakesResult.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (checkMistakesID() == true)
            {
                buttonChangeCheck = true;
                ActionResult<Cakes> cakesResult = cakesController.Get(textBox1.Text);

                List<Cakes> listRes = new List<Cakes>();
                listRes.Add(cakesResult.Value);
                dataGridView2.DataSource = listRes;
            }
            
        }

        private void getInfoId_Click(object sender, EventArgs e)
        {
            
            if (checkMistakesID() == true)
            {
                
                ActionResult<Cakes> cakesResult = cakesController.Get(textBox1.Text);

                List<Cakes> listRes = new List<Cakes>();
                listRes.Add(cakesResult.Value);
                dataGridView1.DataSource = listRes;
            }
        }

        private void deleteInfoId_Click(object sender, EventArgs e)
        {
            
            if (checkMistakesID() == true)
            {
                //OkObjectResult okObjectResult;
                 ActionResult result = cakesController.Delete(textBox1.Text);
                
                 var result3 = (ObjectResult)result; //Код запроса
                
                if (404 != result3.StatusCode)
                { MessageBox.Show("Объект удален"); }

            }
        }

        private void postInfo_Click(object sender, EventArgs e)
        {
            //Cleaner();
            List<Cakes> postList = new List<Cakes>();
            Cakes cakes = new Cakes();
            
            cakes.Name = "";
            cakes.Type = "";
            cakes.Weight = "";
            cakes.Price = 0;
          
            postList.Add(cakes);
            dataGridView2.DataSource = postList;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckDatagrid() == true)
            {
                Cakes cakes = new Cakes();
                cakes.Id = "";

                cakes.Name = (string)dataGridView2[1, 0].Value;
                cakes.Type = (string)dataGridView2[2, 0].Value;
                cakes.Weight = (string)dataGridView2[3, 0].Value;
                cakes.Price = (int)dataGridView2[4, 0].Value;

                cakesController.Post(cakes);
                Cleaner();
            }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (buttonChangeCheck == true)
            {
                Cakes cakes = new Cakes();
                cakes.Id = textBox1.Text;
                cakes.Name = (string)dataGridView2[1, 0].Value;
                cakes.Type = (string)dataGridView2[2, 0].Value;
                cakes.Weight = (string)dataGridView2[3, 0].Value;
                cakes.Price = (int)dataGridView2[4, 0].Value;

                cakesController.Put(textBox1.Text, cakes);
                Cleaner();
            }
            else
                MessageBox.Show("Вы забыли нажать кнопку <<изменить по id>>");
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
