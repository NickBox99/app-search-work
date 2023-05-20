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
    public partial class TypeOfApplicants : Form
    {
        public TypeOfApplicants()
        {
            InitializeComponent();
            TypeOfApplicantsSql.renderTable(dataGridView1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            new TypeOfApplicantAdd().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = getRowSelectedId();

            if (id != -1)
            {
                new TypeOfApplicantEdit(id).Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = getRowSelectedId();

            if (id != -1)
            {
                TypeOfApplicantsSql.delete(id);
                TypeOfApplicantsSql.renderTable(dataGridView1);
                MessageBox.Show("Удалено");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TypeOfApplicantsSql.renderTable(dataGridView1);
            MessageBox.Show("Обновлено");
        }
    }
}
