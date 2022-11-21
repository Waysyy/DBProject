using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using MongoDB.Bson;
using Newtonsoft.Json;

using projectFront.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;


using ZstdSharp.Unsafe;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json.Linq;

namespace projectFront
{
    public partial class AuthForm : Form
    {
        static HttpClient httpClient = new HttpClient();
        

        
        public AuthForm()
        {
            InitializeComponent();
        }
        public string tok { get; set; } = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {

            System.IO.File.Decrypt("token.txt");
            
            string tokenVal = GetValues(textBox1.Text, textBox2.Text);
            if (tokenVal != null)
            {
               
                System.IO.File.WriteAllText("token.txt", tokenVal);
                


                
                string text1 = System.IO.File.ReadAllText("token.txt");
                System.IO.File.Encrypt("token.txt");
                Form menuForm = new mainMenu();
                menuForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Проверьте введенные данные");

        }
        
        static string GetValues(string login, string password)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:7221/token"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");

                    request.Content = new StringContent("{\n  \"userName\": \"" + login + "\",\n  \"password\": \""+password+"\"\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/json");

                    var response =  httpClient.SendAsync(request).Result;
                    string token = response.Content.ReadAsStringAsync().Result;
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        
                        if (token.Contains("admin"))
                        {
                            token = token.Remove(0, 17);
                            token = token.Remove(token.Length - 21, 21);
                        }
                        else
                        {
                            token = token.Remove(0, 17);
                            token = token.Remove(token.Length - 20, 20);
                        }

                        
                        return token;
                    }
                    else
                    {
                        
                        return null; 
                    }
                    
                    
                    
                }
            }
        }
        
       public string GetToken(string token)
        {
            
            return token;
            
        }
    }


}
