using SearchWork.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace SearchWork
{
    public partial class VacanciesAdd : Form
    {
        int _employerId;
        public VacanciesAdd(int employerId)
        {
            InitializeComponent();
            _employerId= employerId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var salary = numericUpDown1.Value;
            var minAge = Convert.ToInt32(numericUpDown2.Value);
            var maxAge = Convert.ToInt32(numericUpDown3.Value);
            var requirements = textBox1.Text;
            var workSchedule = textBox2.Text;
            var vacancyStatus = comboBox1.Text;
            var additionalInfo = textBox3.Text;

            if (minAge > maxAge)
            {
                MessageBox.Show("Возраст неверно задан");
                return;
            }

            if (requirements.Length == 0 || workSchedule.Length == 0 || vacancyStatus.Length == 0 || additionalInfo.Length == 0)
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            VacanciesSql.add(_employerId, salary, minAge, maxAge, requirements, workSchedule, vacancyStatus, additionalInfo);
            MessageBox.Show("Выполнено, обновите таблицу");
            Close();
        }
    }
}
