﻿using SearchWork.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchWork
{
    public partial class MilitaryRegistrationAdd : Form
    {
        public MilitaryRegistrationAdd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;

            if (name.Length == 0)
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            MilitaryRegistrationsSql.add(name);
            MessageBox.Show("Выполнено, обновите таблицу");
            Close();
        }
    }
}
