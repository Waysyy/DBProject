using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.SecurityNamespace;
using Newtonsoft.Json;
using projectFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace projectFront
{
    public partial class CakesForm : Form
    {
        MistakeChecker mistakes = new MistakeChecker();
        bool buttonChangeCheck = false;

        

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
            if (dataGridView2 == null)
            {
                check = false;
                MessageBox.Show("Заполните все поля");

            }
            return check;
        }

        public void Cleaner()
        {
            dataGridView1.DataSource = new object();
            textBox1.Text = null;
            dataGridView2.DataSource = new object();
        }

        
        public CakesForm()
        {
            InitializeComponent();
            CheckRole checkRole = new CheckRole();
            if (checkRole.RoleChecker() == "admin")
            {
                button3.Enabled = true;
                deleteInfoId.Enabled = true;
                postInfo.Enabled = true;
            }
            if (checkRole.RoleChecker() == "user")
            {
                button3.Enabled = false;
                deleteInfoId.Enabled = false;
                postInfo.Enabled = false;
            }
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

            System.IO.File.Decrypt("token.txt");
            string token = System.IO.File.ReadAllText("token.txt");
          
            Deserilize(Get(token));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (mistakes.checkMistakesID(textBox1.Text).isError == true)
            {
                
                buttonChangeCheck = true;
                
                string token = System.IO.File.ReadAllText("token.txt");
                

                DeserilizeToDG2(GetID(token, textBox1.Text));


            }
            else
            {
                MessageBox.Show(mistakes.checkMistakesID(textBox1.Text).errorMessage);
            }
            
        }

        private void getInfoId_Click(object sender, EventArgs e)
        {
            
            if (mistakes.checkMistakesID(textBox1.Text).isError == true)
            {

                string token = System.IO.File.ReadAllText("token.txt");
               
                DeserilizeNotArr(GetID(token, textBox1.Text));
            }
            else
            {
                MessageBox.Show(mistakes.checkMistakesID(textBox1.Text).errorMessage);
            }
        }

        private void deleteInfoId_Click(object sender, EventArgs e)
        {
            
            if (mistakes.checkMistakesID(textBox1.Text).isError == true)
            {
                string token = System.IO.File.ReadAllText("token.txt");
                
                DeleteId(token, textBox1.Text);

            }
            else
            {
                MessageBox.Show(mistakes.checkMistakesID(textBox1.Text).errorMessage);
            }
        }

        private void postInfo_Click(object sender, EventArgs e)
        {
            
            List<Cakes> postList = new List<Cakes>();
            Cakes cakes = new Cakes();
            cakes.Id = "Automatic";
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
                
                cakes.Name = (string)dataGridView2[1, 0].Value;
                cakes.Type = (string)dataGridView2[2, 0].Value;
                cakes.Weight = (string)dataGridView2[3, 0].Value;
                cakes.Price = (int)dataGridView2[4, 0].Value;

                string token = System.IO.File.ReadAllText("token.txt");
                Post(token, cakes);
                
            }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if ( CheckDatagrid() == true)
            {
                Cakes cakes = new Cakes();
                cakes.Id = textBox1.Text;
                cakes.Name = (string)dataGridView2[1, 0].Value;
                cakes.Type = (string)dataGridView2[2, 0].Value;
                cakes.Weight = (string)dataGridView2[3, 0].Value;
                cakes.Price = (int)dataGridView2[4, 0].Value;
                
                    string token = System.IO.File.ReadAllText("token.txt");
                    ChangeID(token, textBox1.Text, cakes);
                
                
            }
            if (dataGridView2 == null)
            { MessageBox.Show("Нет данных для изменения"); }
            //else
                //MessageBox.Show("Вы забыли нажать кнопку <<изменить по id>>");
            
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
        static string Get(string token)
        {


            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7221/Cakes"))
                {

                    request.Headers.TryAddWithoutValidation("accept", "text/plain");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    var response = httpClient.SendAsync(request).Result;
                    
                    return token = response.Content.ReadAsStringAsync().Result;



                }
            }
        }

        static async Task Post(string token, Cakes cake)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:7221/Cakes"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    request.Content = new StringContent("{\n  \"id\": \"\",\n  \"name\": \"" + cake.Name+ "\",\n  \"type\": \""+cake.Type+"\",\n  \"weight\": \""+cake.Weight+"\",\n  \"price\": "+cake.Price+ ",\n  \"ingredients\": [\n    \"string\"\n  ]\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    var t = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    { MessageBox.Show("У вас недостаточно прав");
                        return;
                    }
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    { MessageBox.Show("Готово");  return; }
                    else
                    { MessageBox.Show("Ошибочка " + response.StatusCode); }


                }
            }
        }

        static string GetID(string token, string id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7221/Cakes/"+id))
                {
                    request.Headers.TryAddWithoutValidation("accept", "text/plain");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    var response = httpClient.SendAsync(request).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return token = response.Content.ReadAsStringAsync().Result; 
                    }   
                    else
                    {
                        MessageBox.Show("Ошибочка вышла");
                        return null;
                    }
                        
                }
            }
        }

        static async Task ChangeID(string token, string id, Cakes cake)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PUT"), "https://localhost:7221/Cakes/" + id))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    request.Content = new StringContent("{\n  \"id\": \""+id+"\",\n  \"name\": \"" + cake.Name + "\",\n  \"type\": \"" + cake.Type + "\",\n  \"weight\": \"" + cake.Weight + "\",\n  \"price\": " + cake.Price + ",\n  \"ingredients\": [\n    \"string\"\n  ]\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    { MessageBox.Show("У вас недостаточно прав");  return;}
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    { MessageBox.Show("Готово");  return; }
                    if (response.StatusCode == System.Net.HttpStatusCode.MethodNotAllowed)
                    { MessageBox.Show("Проблемы с ID"); return; }
                    else
                    { MessageBox.Show("Ошибочка " + response.StatusCode); }

                }
            }
        }

        static async Task DeleteId(string token, string id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), "https://localhost:7221/Cakes/" + id))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    var response = await httpClient.SendAsync(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    { MessageBox.Show("У вас недостаточно прав");  return;}
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    { MessageBox.Show("Готово");  return; }
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    { MessageBox.Show("Готово"); return; }
                    else
                    { MessageBox.Show("Ошибочка " + response.StatusCode); }

                }
            }
        }

        public void Deserilize(string json)
        {
            try
            {
                if (json != null)
                {
                    var jobj = JsonConvert.DeserializeObject<List<Cakes>>(json);
                    if (jobj != null)
                    {
                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = jobj;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибочка вышла \n" + ex); }
        }
        public void DeserilizeNotArr(string json)
        {
            try{ 
                if(json != null)
                {
                    var jobj = JsonConvert.DeserializeObject<Cakes>(json);
                    if (jobj != null)
                    {
                        List<Cakes> listRes = new List<Cakes>();
                        listRes.Add(jobj);
                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = listRes;
                    }
                }
            
        }
            catch (Exception ex) { MessageBox.Show("Ошибочка вышла \n" + ex); }
        }

        public void DeserilizeToDG2(string json)
        {
            try {
                if (json != null)
                {
                    var jobj = JsonConvert.DeserializeObject<Cakes>(json);
                    if (jobj != null)
                    {
                        List<Cakes> listRes = new List<Cakes>();
                        listRes.Add(jobj);
                        dataGridView2.AutoGenerateColumns = true;
                        dataGridView2.DataSource = listRes;
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show("Ошибочка вышла \n" + ex); }

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Cleaner();
        }
    }
}
