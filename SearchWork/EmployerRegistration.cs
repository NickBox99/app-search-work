using SearchWork.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchWork
{
    public partial class EmployerRegistration : Form
    {
        string _login;
        string _password;
        public EmployerRegistration(string login, string password)
        {
            InitializeComponent();
            _login = login;
            _password = password;
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

            EmployersSql.create(_login, _password, name, inn, status, address, phone, additionalInfo);
            new EmployerMenu().Show();
            Close();
        }
    }
}
