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
    public partial class PersonalsForm : Form
    {
        public PersonalsForm()
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

        PersonalsController personalsController = new PersonalsController();
        private void getInfo_Click(object sender, EventArgs e)
        {
            ActionResult<List<Personals>> personalsResult = personalsController.Get();
            dataGridView1.DataSource = personalsResult.Value;
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

            Personals personals = new Personals();
            personals.Id = textBox1.Text;
            personals.Name = (string)dataGridView2[1, 0].Value;
            personals.Lastname = (string)dataGridView2[2, 0].Value;
            personals.JobTitle = (string)dataGridView2[3, 0].Value;
            personals.Salary = (int)dataGridView2[4, 0].Value;
            personals.Manager = (string)dataGridView2[5, 0].Value;


            personalsController.Put(textBox1.Text, personals);
            Cleaner();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {

                ActionResult<Personals> personalsResult = personalsController.Get(textBox1.Text);

                List<Personals> listRes = new List<Personals>();
                listRes.Add(personalsResult.Value);
                dataGridView2.DataSource = listRes;
            }

        }

        private void getInfoId_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {

                ActionResult<Personals> personalsResult = personalsController.Get(textBox1.Text);

                List<Personals> listRes = new List<Personals>();
                listRes.Add(personalsResult.Value);
                dataGridView1.DataSource = listRes;
            }
        }

        private void deleteInfoId_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {
                ActionResult result2 = null;
                ActionResult result = personalsController.Delete(textBox1.Text);
                var result3 = (OkObjectResult)result; //Код запроса
                if (result != result3.Value)
                { MessageBox.Show("Объект удален"); }

            }
        }

        private void postInfo_Click(object sender, EventArgs e)
        {
            //Cleaner();
            List<Personals> postList = new List<Personals>();
            Personals personals = new Personals();

            personals.Name = "";
            personals.Lastname = "";
            personals.JobTitle = "";
            personals.Salary = 0;
            personals.Manager = "";

            postList.Add(personals);
            dataGridView2.DataSource = postList;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            Personals personals = new Personals();
            personals.Id = "";
            personals.Name = (string)dataGridView2[1, 0].Value;
            personals.Lastname = (string)dataGridView2[2, 0].Value;
            personals.JobTitle = (string)dataGridView2[3, 0].Value;
            personals.Salary = (int)dataGridView2[4, 0].Value;
            personals.Manager = (string)dataGridView2[5, 0].Value;

            personalsController.Post(personals);
            Cleaner();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
