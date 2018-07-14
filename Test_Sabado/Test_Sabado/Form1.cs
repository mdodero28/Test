using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Sabado
{
    public partial class TestSabado : Form
    {
        public TestSabado()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ('-'.Equals(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ('\b'.Equals(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("No se admiten letras");
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int suma = 0;
                String errorLog = String.Empty;
                String[] lsTxtNumeros = textBox1.Text.Split(' ');
                foreach (String num in lsTxtNumeros)
                {
                    if (!String.Empty.Equals(num))
                    {
                        if (ValidateNumber(num))
                            suma += Convert.ToInt32(num);
                        else
                            errorLog = "Existe un numero con formato incorrecto";
                    }
                }
                textBox2.Text = Convert.ToString(suma);
                if (!String.Empty.Equals(errorLog))
                    MessageBox.Show(errorLog);
            }
            catch (Exception)
            {
                Console.WriteLine("Error inesperado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private Boolean ValidateNumber(String num)
        {
            if (num.Contains("--"))
                return false;
            else if (num.Contains("-") && !num.StartsWith("-"))
                return false;
            return true;
        }


    }
}
