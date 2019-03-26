using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double f(double x, ref int k1)  // Ліві частини рівнянь
        {
            switch (k1)
            {
                case 0: return x * x - 4;
                case 1: return 3 * x - 4 * Math.Log(x) - 5;
                case 2: return Math.Sin(x + 2) - x * x + 2 * x - 1;
            }
            return 0;
        }
        double fp(double x, double d, ref int k1)   // Перша похідна
        {
            return (f(x + d, ref k1) - f(x, ref k1)) / d;
        }
        double f2p(double x, double d, ref int k1)  // Друга похідна
        {
            return (f(x + d, ref k1) + f(x - d, ref k1) - 2 * f(x, ref k1)) / (d * d);
        }
        double MDP(double a, double b, double Eps, ref int k1, ref int L)
        {
            double c = 0, Fc; while (b - a > Eps)
            {
                c = 0.5 * (b - a) + a;
                L++;    // Лічильник кількості поділів інтервалу [a, b]
                Fc = f(c, ref k1);
                if (Math.Abs(Fc) < Eps) // Перевірка, чи точка с не є поблизу кореня x*
                    return c;   // Завершення роботи функції MDP
                if (f(a, ref k1) * Fc > 0) a = c; else b = c;
            }
            return c;   // Завершення роботи функції MDP
        }

        double MN(double a, double b, double Eps, ref int k1, int Kmax, ref int L)
        {
            double x, Dx, D;
            int i;
            Dx = 0.0; D = Eps / 100.0;
            x = b;
            if (f(x, ref k1) * f2p(x, D, ref k1) < 0) x = a;

            if (f(x, ref k1) * f2p(x, D, ref k1) < 0)
                MessageBox.Show("Для цього рівняння збіжність ітерацій не гарантована");
            for (i = 1; i <= Kmax; i++)
            {
                Dx = f(x, ref k1) / fp(x, D, ref k1); x = x - Dx;
                if (Math.Abs(Dx) < Eps)
                {
                    L = i;
                    return x;   // Завершення роботи функції MN
                }
            }
            MessageBox.Show("За задану кількість ітерацій кореня не знайдено");
            return -1000.0; // -1000.0 Це наша ознака цієї нестандартної ситуації
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        label7.Visible = false;   // Робимо невидимим вікно для введення Kmax 
                        textBox4.Visible = false;
                        textBox1.Clear(); textBox2.Clear();
                    }
                    break;
                case 1:
                    {
                        label7.Visible = true;    // Робимо видимим вікно для введення Kmax 
                        textBox4.Visible = true;
                        textBox1.Clear(); textBox2.Clear();
                    }
                    break;
            }
        }
      

        private void button1_Click_1(object sender, EventArgs e)
        {
            
                int L, k = -1, Kmax, m = -1; double D, Eps = 0, a, b;
                L = 0;
                switch (comboBox1.SelectedIndex)    // Вибір чисельного методу :
                {
                    case 0: m = 0; break;   // метод ділення навпіл
                    case 1: // метод Ньютона
                        {
                            m = 1;
                            D = Eps / 100.0;
                            label7.Visible = true;  // Робимо видимим вікно для введення Kmax
                        textBox4.Visible = true;
                            textBox4.Enabled = true;
                        }
                        break;
                }
                if (m == -1)
                {
                    MessageBox.Show("Оберіть метод !"); comboBox1.Focus();
                    return;
                }
                textBox1.Enabled = true;

                textBox2.Enabled = true;
                switch (comboBox2.SelectedIndex)    // Вибір нелінійного рівняння
                {
                    case 0: k = 0; break;
                    case 1: k = 1; break;
                    case 2: k = 2; break; 
                }
                if (k == -1)
                {
                    MessageBox.Show("Оберіть рівняння !"); comboBox2.Focus();
                    return;
                }
            // Перевіряємо правильність введення вхідних даних
                    if (textBox1.Text == "")
                {
                    MessageBox.Show("Введіть число в textBox1"); textBox1.Focus();
                    return;
                }
                a = Convert.ToDouble(textBox1.Text); textBox2.Enabled = true;
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введіть число в textBox2"); textBox2.Focus();
                    return;
                }
                b = Convert.ToDouble(textBox2.Text);
                if (a > b)
                {
                    D = a; a = b; b = D;  // Міняємо місцями a і b 
                    textBox1.Text = Convert.ToString (a);
                    textBox2.Text = Convert.ToString(b);
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Введіть число в textBox3"); textBox1.Focus();
                    return;
                }
                Eps = Convert.ToDouble(textBox3.Text);
                if ((Eps > 1e-1) || (Eps <= 0)) // Похибка Eps не повинна бути більшою за 0.1 або меншою за 0
                {
                // Задаємо примусово
                Eps = 0.0001; 
                textBox3.Text = Convert.ToString (Eps);
                }
                if (m == 0)
                    if ((f(a, ref k)) * (f(b, ref k)) > 0)  // чи є корінь на інтервалі [a,b]
                    {
                        MessageBox.Show("Введіть правильний інтервал [a, b]!");
                        textBox1.Text = "";
                        textBox2.Text = ""; textBox1.Focus();
                        return;
                    }
                    // Перевіряємо, чи межі інтервалу [a,b] не є поблизу кореня 
                    if (Math.Abs(f(a, ref k)) < Eps)
                        {
                        textBox5.Text = Convert.ToString(a);
                        textBox6.Text = Convert.ToString(L); return;
                        }
                        if (Math.Abs(f(b, ref k)) < Eps)
                        {
                        textBox5.Text = Convert.ToString(b);
                        textBox6.Text = Convert.ToString(L); return;
                        }
                        switch (m)
                        {
                            case 0: // Виклик методу ділення навпіл MDP
                                {
                                    textBox5.Text = Convert.ToString(MDP(a, b, Eps, ref k, ref L));
                                    textBox6.Text = Convert.ToString(L);
                                    label10.Text = "К-ть поділів =";
                                }
                                break;

                            case 1: // Виклик методу Ньютона MN
                                {
                                    if (textBox4.Text == "")
                                    {
                                        MessageBox.Show("Введіть число в textBox4"); textBox4.Focus();
                                        return;
                                    }
                                    Kmax = Convert.ToInt32(textBox4.Text);
                                    textBox5.Text = Convert.ToString(MN(a, b, Eps, ref k, Kmax, ref L)); textBox6.Text = Convert.ToString(L);
                                    label10.Text = "К-ть ітерац.=";
                                }
                                break;
                        }
                    }
            

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        label7.Visible = false; // Робимо невидимим вікно для введення Kmax
                        textBox4.Visible = false;
                    }
                    break;
                case 1:
                    {
                        label7.Visible = true;  // Робимо видимим вікно для введення Kmax 
                        textBox4.Visible = true;
                    }
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

