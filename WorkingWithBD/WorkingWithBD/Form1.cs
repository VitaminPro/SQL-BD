using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace WorkingWithBD
{
    public partial class Form1 : Form
    {

        public Form1()
        {    
            InitializeComponent();
        }


        private  void button1_Click(object sender, EventArgs e) //добавление
        {
            
            if (!label7.Visible)
                label7.Visible = false;
            

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SportProductShop n2 = new SportProductShop();
                 n2.AddNewProduct(textBox1.Text, textBox2.Text);
               
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Поля  'Имя' и 'Цена' должны быть заполнены!";
            }
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
      {

       }

        private  void Form1_Load(object sender, EventArgs e)
        {
            
           
            //Обработчик исключений
            try
            {
                SportProductShop n1 = new SportProductShop();
                List<SportProduct> list =   n1.GetAllProducts();
                 

                foreach(SportProduct o in list )
                {
                
                    listBox1.Items.Add(Convert.ToString(o.ID) +"   "+ Convert.ToString(o.Name) + "   " + Convert.ToString(o.Price));
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private  void обновитьToolStripMenuItem_Click(object sender, EventArgs e) //обновление
        {

        
            listBox1.Items.Clear();

            try
            {
                SportProductShop n1 = new SportProductShop();
                List<SportProduct> list = n1.GetAllProducts();


                foreach (SportProduct o in list)
                {

                    listBox1.Items.Add(Convert.ToString(o.ID) + "   " + Convert.ToString(o.Name) + "   " + Convert.ToString(o.Price));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private  void button2_Click(object sender, EventArgs e) //Изменение
        {
            

            if (!label8.Visible)
                label8.Visible = false;

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)&&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)&&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SportProductShop n1 = new SportProductShop();
                n1.Update(textBox5.Text, textBox4.Text, textBox3.Text);
            }
          
            else if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
                {

                label8.Visible = true;
                label8.Text = "ID должен быть заполнен";
                }
            else
            {
                label8.Visible = true;
                label8.Text = "Поля  'Имя' или 'Цена' должны быть заполнены!";
            }
            

        }

        private  void button3_Click(object sender, EventArgs e) //удаление по id
        {
            
            if (!label9.Visible)
                label9.Visible = false;

            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SportProductShop n1 = new SportProductShop();
                n1.Delete(Convert.ToInt32(textBox6.Text));
            }

            else
            {
                label9.Visible = true;
                label9.Text = "ID должен быть заполнен";

            }
            
        }
    }
}
