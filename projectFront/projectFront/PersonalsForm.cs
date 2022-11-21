﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using projectFront.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectFront
{
    public partial class PersonalsForm : Form
    {
        bool buttonChangeCheck = false;
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
        public PersonalsForm()
        {
            InitializeComponent();
        }

        

        public void Cleaner()
        {
            dataGridView1 = null;
            textBox1.Text = null;
            dataGridView2 = null;
        }

        private void getInfo_Click(object sender, EventArgs e)
        {

            System.IO.File.Decrypt("token.txt");
            string token = System.IO.File.ReadAllText("token.txt");

            Deserilize(Get(token));
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

            if (buttonChangeCheck == true && CheckDatagrid() == true)
            {
                Personals personals = new Personals();
                personals.Id = textBox1.Text;
                personals.Name = (string)dataGridView2[1, 0].Value;
                personals.Lastname = (string)dataGridView2[2, 0].Value;
                personals.JobTitle = (string)dataGridView2[3, 0].Value;
                personals.Salary = (int)dataGridView2[4, 0].Value;
                personals.Manager = (string)dataGridView2[5, 0].Value;

                string token = System.IO.File.ReadAllText("token.txt");
                ChangeID(token, textBox1.Text, personals);


            }
            else
                MessageBox.Show("Вы забыли нажать кнопку <<изменить по id>>");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {

                buttonChangeCheck = true;

                string token = System.IO.File.ReadAllText("token.txt");


                DeserilizeToDG2(GetID(token, textBox1.Text));


            }

        }

        private void getInfoId_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {

                string token = System.IO.File.ReadAllText("token.txt");

                DeserilizeNotArr(GetID(token, textBox1.Text));
            }
        }

        private void deleteInfoId_Click(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {
                string token = System.IO.File.ReadAllText("token.txt");

                DeleteId(token, textBox1.Text);

            }
        }

        private void postInfo_Click(object sender, EventArgs e)
        {
            //Cleaner();
            List<Personals> postList = new List<Personals>();
            Personals personals = new Personals();
            personals.Id = "Automatic";
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

            string token = System.IO.File.ReadAllText("token.txt");
            Post(token, personals);
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

        static string Get(string token)
        {


            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7221/Personals"))
                {

                    request.Headers.TryAddWithoutValidation("accept", "text/plain");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    var response = httpClient.SendAsync(request).Result;

                    return token = response.Content.ReadAsStringAsync().Result;



                }
            }
        }

        static async Task Post(string token, Personals personal)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:7221/Personals"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    request.Content = new StringContent("{\n  \"id\": \"\",\n  \"name\": \""+personal.Name+"\",\n  \"lastname\": \""+personal.Lastname+"\",\n  \"jobTitle\": \""+personal.JobTitle+"\",\n  \"salary\": "+personal.Salary+",\n  \"manager\": \""+personal.Manager+"\"\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    var t = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    { MessageBox.Show("У вас недостаточно прав"); }
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    { MessageBox.Show("Готово"); }
                    else
                    { MessageBox.Show("Ошибочка " + response.StatusCode); }
                }
            }
        }

        static string GetID(string token, string id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7221/Personals/" + id))
                {
                    request.Headers.TryAddWithoutValidation("accept", "text/plain");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    var response = httpClient.SendAsync(request).Result;

                    return token = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        static async Task ChangeID(string token, string id, Personals personal)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PUT"), "https://localhost:7221/Personals/" + id))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    request.Content = new StringContent("{\n  \"id\": \"" + id + "\",\n  \"name\": \"" + personal.Name + "\",\n  \"lastname\": \"" + personal.Lastname + "\",\n  \"jobTitle\": \"" + personal.JobTitle + "\",\n  \"salary\": " + personal.Salary + ",\n  \"manager\": \"" + personal.Manager + "\"\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    { MessageBox.Show("У вас недостаточно прав"); }
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    { MessageBox.Show("Готово"); }
                    else
                    { MessageBox.Show("Ошибочка " + response.StatusCode); }

                }
            }
        }

        static async Task DeleteId(string token, string id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), "https://localhost:7221/Personals/" + id))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    var response = await httpClient.SendAsync(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    { MessageBox.Show("У вас недостаточно прав"); }
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    { MessageBox.Show("Готово"); }
                    else
                    { MessageBox.Show("Ошибочка " + response.StatusCode); }

                }
            }
        }

        public void Deserilize(string json)
        {
            try
            {
                var jobj = JsonConvert.DeserializeObject<List<Personals>>(json);
                if (jobj != null)
                {
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = jobj;
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибочка вышла \n"); }
        }
        public void DeserilizeNotArr(string json)
        {
            try
            {
                var jobj = JsonConvert.DeserializeObject<Personals>(json);
                if (jobj != null)
                {
                    List<Personals> listRes = new List<Personals>();
                    listRes.Add(jobj);
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = listRes;
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибочка вышла \n"); }
        }

        public void DeserilizeToDG2(string json)
        {
            try
            {
                var jobj = JsonConvert.DeserializeObject<Personals>(json);
                if (jobj != null)
                {
                    List<Personals> listRes = new List<Personals>();
                    listRes.Add(jobj);
                    dataGridView2.AutoGenerateColumns = true;
                    dataGridView2.DataSource = listRes;
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибочка вышла \n"); }

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Cleaner();
        }
    }
}
