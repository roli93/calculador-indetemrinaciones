using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Modelo;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operar(textBox1.Text, textBox2.Text, (a, b) => a.sumarle(b), label5); 
        }

        private void operar(string expresion1, string expresion2,Func<Valor,Valor,Valor> operacion, Label labelResultado)
        {
            try
            {
                Valor a = new Valor(expresion1);
                Valor b = new Valor(expresion2);
                labelResultado.Text = operacion(a,b).ToString();
            }
            catch
            {
                MessageBox.Show("Las expresiones no tienen el formato adecuado", "Error");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            operar(textBox5.Text, textBox6.Text, (a, b) => a.multiplicarPor(b), label7); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            operar(textBox3.Text, textBox4.Text, (a, b) => a.restarle(b), label1); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            operar(textBox7.Text, textBox8.Text, (a, b) => a.dividirPor(b), label10); 
        }


    }
}
