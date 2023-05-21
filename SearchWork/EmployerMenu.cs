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
    public partial class EmployerMenu : Form
    {
        int employerId;
        public EmployerMenu()
        {
            InitializeComponent();

            employerId = (int)EmployersSql.get(Database.Database.authLogin)["id"];

            VacanciesSql.renderTable(dataGridView1, employerId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new EmployerProfile().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new VacanciesAdd(employerId).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VacanciesSql.renderTable(dataGridView1, employerId);
            MessageBox.Show("Обновлено");
        }

        private int getRowSelectedId()
        {
            var value = dataGridView1.CurrentRow?.Cells[0].Value;

            if (value != null)
            {
                return Convert.ToInt32(value);
            }
            else
            {
                MessageBox.Show("Необходимо выбрать строку");
            }

            return -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var id = getRowSelectedId();

            if (id != -1)
            {
                VacanciesSql.delete(id);
                VacanciesSql.renderTable(dataGridView1, employerId);
                MessageBox.Show("Удалено");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var id = getRowSelectedId();

            if (id != -1)
            {
                new VacanciesEdit(employerId, id).Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var id = getRowSelectedId();

            if (id != -1)
            {
                new EmployerResponses(id).Show();
            }
        }
    }
}
