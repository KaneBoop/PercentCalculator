using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PercentCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = "";
            textBox1.ReadOnly = true;
            textBox1.BorderStyle = 0;
            textBox1.BackColor = this.BackColor;
            textBox1.TabStop = false;
            textBox2.Text = "";
            textBox2.ReadOnly = true;
            textBox2.BorderStyle = 0;
            textBox2.BackColor = this.BackColor;
            textBox2.TabStop = false;
            textBox3.Text = "";
            textBox3.ReadOnly = true;
            textBox3.BorderStyle = 0;
            textBox3.BackColor = this.BackColor;
            textBox3.TabStop = false;
            textBox4.Text = "";
            textBox4.ReadOnly = true;
            textBox4.BorderStyle = 0;
            textBox4.BackColor = this.BackColor;
            textBox4.TabStop = false;
            textBoxA.MaxLength = 29;    //decimal.MaxValue.ToString().Length;
            textBoxB.MaxLength = 29;    //decimal.MaxValue.ToString().Length;
            comboBoxRoundTo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRoundTo.Items.Add(0);
            comboBoxRoundTo.Items.Add(1);
            comboBoxRoundTo.Items.Add(2);
            comboBoxRoundTo.Items.Add(3);
            comboBoxRoundTo.SelectedIndex = 2;
            UpdateForm();
        }

        private void UpdateForm()
        {
            decimal.TryParse(textBoxA.Text, out decimal aInput);
            decimal.TryParse(textBoxB.Text, out decimal bInput);
            decimal a = 0, b = 0;
            try
            {
                //if (string.IsNullOrEmpty(textBoxA.Text) || a <= 0 || b <= 0)
                //    throw new Exception("Invalid input");

                if (aInput > bInput || aInput == bInput)
                {
                    a = aInput;
                    b = bInput;

                }
                //else if (aInput < bInput)
                else
                {
                    b = aInput;
                    a = bInput;
                }
                textBox1.Text = string.Format($"{a} составляет {WhatPercentOf(a, b, (int)comboBoxRoundTo.SelectedItem):0.###}% от {b}");
                textBox2.Text = string.Format($"{b} составляет {WhatPercentOf(b, a, (int)comboBoxRoundTo.SelectedItem):0.###}% от {a}");
                textBox3.Text = string.Format($"{a} больше чем {b} на {PercentageChange(a, b, (int)comboBoxRoundTo.SelectedItem):0.###}%");
                textBox4.Text = string.Format($"{b} меньше чем {a} на {PercentageChange(b, a, (int)comboBoxRoundTo.SelectedItem):0.###}%");
            }
            catch (Exception)
            {
                textBox1.Text = "Invalid input";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
        private decimal WhatPercentOf(decimal a, decimal b, int n)
        {
            return Math.Round(a / b * 100, n);
        }

        private decimal PercentageChange(decimal a, decimal b, int n)
        {
            if (a > b)
                return Math.Round((a - b) / b * 100, n);
            else if (a < b)
                return Math.Round((b - a) / b * 100, n);
            else
                return 0;
        }
        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void textBoxB_TextChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void textBoxA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
            }
        }

        private void textBoxB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
            }
        }

        private void comboBoxRoundTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }
    }
}
