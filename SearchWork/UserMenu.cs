using SearchWork.Database;
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
    public partial class UserMenu : Form
    {
        int userId;
        public UserMenu()
        {
            InitializeComponent();
            VacanciesSql.renderTable(dataGridView1);
            userId = (int)UsersSql.get(Database.Database.authLogin)["id"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new UserProfile().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VacanciesSql.renderTable(dataGridView1);
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
                new ResponsesView(id).Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = getRowSelectedId();

            if (id != -1)
            {
                VacanciesSql.sendResponses(id, userId);
                VacanciesSql.renderTable(dataGridView1);
                MessageBox.Show("Отлик отправлен");
            }
        }
    }
}
