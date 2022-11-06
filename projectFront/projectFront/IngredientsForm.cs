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
    public partial class IngredientsForm : Form
    {
        public IngredientsForm()
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

        IngredientsController ingredientsController = new IngredientsController();
        private void getInfo_Click(object sender, EventArgs e)
        {
            ActionResult<List<Ingredients>> ingredientsResult = ingredientsController.Get();
            dataGridView1.DataSource = ingredientsResult.Value;
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

            Ingredients ingredients = new Ingredients();
            ingredients.Id = textBox1.Text;
            ingredients.Name = (string)dataGridView2[1, 0].Value;
            ingredients.ExplorationDate = (DateTime)dataGridView2[2, 0].Value;
            ingredients.InStock = (string)dataGridView2[3, 0].Value;
           


            ingredientsController.Put(textBox1.Text, ingredients);
            Cleaner();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {

                ActionResult<Ingredients> ingredientsResult = ingredientsController.Get(textBox1.Text);

                List<Ingredients> listRes = new List<Ingredients>();
                listRes.Add(ingredientsResult.Value);
                dataGridView2.DataSource = listRes;
            }

        }

        private void getInfoId_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {

                ActionResult<Ingredients> ingredientsResult = ingredientsController.Get(textBox1.Text);

                List<Ingredients> listRes = new List<Ingredients>();
                listRes.Add(ingredientsResult.Value);
                dataGridView1.DataSource = listRes;
            }
        }

        private void deleteInfoId_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {
                ActionResult result2 = null;
                ActionResult result = ingredientsController.Delete(textBox1.Text);
                var result3 = (OkObjectResult)result; //Код запроса
                if (result != result3.Value)
                { MessageBox.Show("Объект удален"); }

            }
        }

        private void postInfo_Click(object sender, EventArgs e)
        {
            //Cleaner();
            List<Ingredients> postList = new List<Ingredients>();
            Ingredients ingredients = new Ingredients();

            ingredients.Name = "";
            ingredients.ExplorationDate = new DateTime();
            ingredients.InStock = "";

            postList.Add(ingredients);
            dataGridView2.DataSource = postList;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            Ingredients ingredients = new Ingredients();
            ingredients.Id = "";
            ingredients.Name = (string)dataGridView2[1, 0].Value;
            ingredients.ExplorationDate = (DateTime)dataGridView2[2, 0].Value;
            ingredients.InStock = (string)dataGridView2[3, 0].Value;

            ingredientsController.Post(ingredients);
            Cleaner();
        }
    }
}
