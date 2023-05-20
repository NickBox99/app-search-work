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
    public partial class MilitaryRegistrations : Form
    {
        public MilitaryRegistrations()
        {
            InitializeComponent();
            GendersSql.renderTable(dataGridView1);
        }

        private int getRowSelectedId()
        {
            var value = dataGridView1.CurrentRow.Cells[0].Value;

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

        private void button1_Click(object sender, EventArgs e)
        {
            new MilitaryRegistrationAdd().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = getRowSelectedId();

            if (id != -1)
            {
                new MilitaryRegistrationEdit(id).Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = getRowSelectedId();

            if (id != -1)
            {
                GendersSql.delete(id);
                GendersSql.renderTable(dataGridView1);
                MessageBox.Show("Удалено");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GendersSql.renderTable(dataGridView1);
            MessageBox.Show("Обновлено");
        }
    }
}
