using SearchWork.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchWork
{
    public partial class EmployerProfile : Form
    {
        int userId;

        public EmployerProfile()
        {
            InitializeComponent();

            var user = EmployersSql.get(Database.Database.authLogin);

            userId = (int)user["id"];
            textBox1.Text = (string)user["name"];
            textBox2.Text = (string)user["inn"];
            comboBox1.Text = (string)user["status"];
            textBox3.Text = (string)user["address"];
            textBox4.Text = (string)user["phone"];
            textBox5.Text = (string)user["additional_info"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var inn = textBox2.Text;
            var status = comboBox1.Text;
            var address = textBox3.Text;
            var phone = textBox4.Text;
            var additionalInfo = textBox5.Text;

            if (!Regex.IsMatch(inn, @"^\d{20}$"))
            {
                MessageBox.Show("Заполните поле: ИНН (20 цифр)");
                return;
            }

            if (!Regex.IsMatch(phone, @"^\d{11}$"))
            {
                MessageBox.Show("Заполните поле: Телефон (11 цифр)");
                return;
            }

            if (name.Length == 0 || status.Length == 0 || address.Length == 0 || phone.Length == 0 || additionalInfo.Length == 0)
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            EmployersSql.update(userId, name, inn, status, address, phone, additionalInfo);
            MessageBox.Show("Данные обновлены");
            Close();
        }
    }
}
