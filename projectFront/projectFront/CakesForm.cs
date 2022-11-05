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

            string i = cakesResult.Value[1].Name;
            dataGridView1.DataSource = cakesResult.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActionResult<Cakes> cakesResult = cakesController.Get(textBox1.Text);

            List<Cakes> listRes = new List<Cakes>();
            listRes.Add(cakesResult.Value);
            dataGridView2.DataSource = listRes;
        }

        private void getInfoId_Click(object sender, EventArgs e)
        {
            //var result3 = (OkObjectResult)result.Result; // <-- Cast is before using it.
            //<-- Then you'll get no error here.
            ActionResult<Cakes> cakesResult = cakesController.Get(textBox1.Text);

            List<Cakes> listRes = new List<Cakes>();
            listRes.Add(cakesResult.Value);
            dataGridView1.DataSource = listRes;
        }

        private void deleteInfoId_Click(object sender, EventArgs e)
        {
            ActionResult result2 = null;
            ActionResult result = cakesController.Delete(textBox1.Text);
            var result3 = (OkObjectResult)result; //Код запроса
            if (result != result3.Value)
            { MessageBox.Show("Объект удален"); }


        }

        private void postInfo_Click(object sender, EventArgs e)
        {

            List<Cakes> postList = new List<Cakes>();
            Cakes cakes = new Cakes();
            cakes.Id = "";
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
            
            Cakes cakes = new Cakes();
            cakes.Id = "";
            cakes.Name = (string)dataGridView2[1, 0].Value;
            cakes.Type = (string)dataGridView2[2, 0].Value;
            cakes.Weight = (string)dataGridView2[3, 0].Value;
            cakes.Price = (int)dataGridView2[4, 0].Value;

            cakesController.Post(cakes);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Cakes cakes = new Cakes();
            cakes.Id = textBox1.Text;
            cakes.Name = (string)dataGridView2[1, 0].Value;
            cakes.Type = (string)dataGridView2[2, 0].Value;
            cakes.Weight = (string)dataGridView2[3, 0].Value;
            cakes.Price = (int)dataGridView2[4, 0].Value;

            cakesController.Put(textBox1.Text, cakes);
        }
    }
}
