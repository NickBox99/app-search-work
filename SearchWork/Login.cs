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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;
            var type = comboBox1.Text;

            if (login.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            if (type.Length == 0)
            {
                MessageBox.Show("Выберите тип регистрации");
                return;
            }

            var isUser = type == "Соискатель";

            if (isUser)
            {
                var errorMessage = UsersSql.init(login, password);

                if (errorMessage == "Соискатель не найден")
                {
                    new UserRegistration(login, password).Show();
                }
                else
                {
                    MessageBox.Show("Соискатель уже зарегистрирован");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;
            var type = comboBox1.Text;

            if (login.Length == 0 || password.Length == 0) {
                MessageBox.Show("Заполните поля");
                return;
            }

            if (type.Length == 0)
            {
                MessageBox.Show("Выберите тип регистрации");
                return;
            }

            var isUser = type == "Соискатель";

            if (isUser)
            {
                var errorMessage = UsersSql.init(login, password);

                if (errorMessage.Length == 0)
                {
                    Database.Database.authLogin = login;
                    new UserMenu().Show();
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
        }
    }
}
