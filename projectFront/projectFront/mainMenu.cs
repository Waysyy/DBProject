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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form cakesForm = new CakesForm();
            cakesForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ordersForm = new OrdersForm();
            ordersForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form personalsForm = new PersonalsForm();
            personalsForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form clientsForm = new ClientsForm();
            clientsForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form ingredientsForm = new IngredientsForm();
            ingredientsForm.Show();
            this.Hide();
        }
    }
}
