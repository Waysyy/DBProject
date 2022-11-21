using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
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
using Application = System.Windows.Forms.Application;

namespace projectFront
{
    public partial class OrdersForm : Form
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
        public OrdersForm()
        {
            InitializeComponent();
        }
        

        public void Cleaner()
        {
            dataGridView1.DataSource = new object();
            textBox1.Text = null;
            dataGridView2.DataSource = new object();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form thisForm = Application.OpenForms[1];
            thisForm.Show();
        }
        private void getInfo_Click(object sender, EventArgs e)
        {

            System.IO.File.Decrypt("token.txt");
            string token = System.IO.File.ReadAllText("token.txt");

            Deserilize(Get(token));
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            if (checkMistakesID() == true)
            {

                buttonChangeCheck = true;

                string token = System.IO.File.ReadAllText("token.txt");


                DeserilizeToDG2(GetID(token, textBox1.Text));


            }
        }

        private void getInfoId_Click_1(object sender, EventArgs e)
        {
            if (checkMistakesID() == true)
            {

                string token = System.IO.File.ReadAllText("token.txt");

                DeserilizeNotArr(GetID(token, textBox1.Text));
            }
        }

        private void deleteInfoId_Click_1(object sender, EventArgs e)
        {

            if (checkMistakesID() == true)
            {
                string token = System.IO.File.ReadAllText("token.txt");

                DeleteId(token, textBox1.Text);

            }
        }

        private void postInfo_Click_1(object sender, EventArgs e)
        {
            //Cleaner();
            List<Orders> postList = new List<Orders>();
            Orders orders = new Orders();
            orders.Id = "Automatic";
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

            if (buttonChangeCheck == true && CheckDatagrid() == true)
            {
                Orders orders = new Orders();
                orders.Id = textBox1.Text;
                orders.Client = (string)dataGridView2[1, 0].Value;
                orders.DateOrd = (DateTime)dataGridView2[2, 0].Value;
                orders.Cook = (string)dataGridView2[3, 0].Value;
                orders.Cake = (string)dataGridView2[4, 0].Value;
                orders.Price = (int)dataGridView2[5, 0].Value;

                string token = System.IO.File.ReadAllText("token.txt");
                ChangeID(token, textBox1.Text, orders);


            }
            else
                MessageBox.Show("Вы забыли нажать кнопку <<изменить по id>>");
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

            string token = System.IO.File.ReadAllText("token.txt");
            Post(token, orders);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form menuForm = new mainMenu();
            menuForm.Show();
            this.Close();
        }
        static string Get(string token)
        {


            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7221/Orders"))
                {

                    request.Headers.TryAddWithoutValidation("accept", "text/plain");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    var response = httpClient.SendAsync(request).Result;

                    return token = response.Content.ReadAsStringAsync().Result;



                }
            }
        }

        static async Task Post(string token, Orders order)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:7221/Orders"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    request.Content = new StringContent("{\n  \"id\": \"\",\n  \"client\": \""+order.Client+"\",\n  \"dateOrd\": \""+ ($"{order.DateOrd:s}") + "\",\n  \"cook\": \""+order.Cook+"\",\n  \"cake\": \""+order.Cake+"\",\n  \"price\": "+order.Price+"\n}");
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
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7221/Orders/" + id))
                {
                    request.Headers.TryAddWithoutValidation("accept", "text/plain");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    var response = httpClient.SendAsync(request).Result;

                    return token = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        static async Task ChangeID(string token, string id, Orders order)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PUT"), "https://localhost:7221/Orders/" + id))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    request.Content = new StringContent("{\n  \"id\": \"" + id + "\",\n  \"client\": \"" + order.Client + "\",\n  \"dateOrd\": \"" + ($"{order.DateOrd:s}") + "\",\n  \"cook\": \"" + order.Cook + "\",\n  \"cake\": \"" + order.Cake + "\",\n  \"price\": " + order.Price + "\n}");
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
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), "https://localhost:7221/Orders/" + id))
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
                var jobj = JsonConvert.DeserializeObject<List<Orders>>(json);
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
                var jobj = JsonConvert.DeserializeObject<Orders>(json);
                if (jobj != null)
                {
                    List<Orders> listRes = new List<Orders>();
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
                var jobj = JsonConvert.DeserializeObject<Orders>(json);
                if (jobj != null)
                {
                    List<Orders> listRes = new List<Orders>();
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
