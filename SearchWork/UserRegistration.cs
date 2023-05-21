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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace SearchWork
{
    public partial class UserRegistration : Form
    {
        string _login;
        string _password;
        public UserRegistration(string login, string password)
        {
            InitializeComponent();
            _login = login;
            _password = password;

            Database.Database.renderCombobox(comboBox4, "genders", "name");
            Database.Database.renderCombobox(comboBox5, "military_registrations", "name");
            Database.Database.renderCombobox(comboBox6, "type_of_applicants", "name");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fio = textBox1.Text;
            var dateOfBirth = dateTimePicker1.Value;
            var address = textBox2.Text;
            var phone = textBox3.Text;
            var experience = comboBox1.Text;
            var resume = comboBox2.Text;
            var education = comboBox3.Text;
            var salary = numericUpDown1.Value;
            var position = textBox4.Text;
            var genderId = comboBox4.SelectedValue;
            var militaryRegistrationId = comboBox5.SelectedValue;
            var typeOfApplicantId = comboBox6.SelectedValue;

            if (!Regex.IsMatch(phone, @"^\d{11}$"))
            {
                MessageBox.Show("Заполните поле: Телефон (11 цифр)");
                return;
            }

            if (fio.Length == 0 || address.Length == 0 || experience.Length == 0 || resume.Length == 0 || education.Length == 0 || position.Length == 0 || genderId == null || typeOfApplicantId == null || militaryRegistrationId == null) {
                MessageBox.Show("Заполните поля");
                return;
            }

            UsersSql.create(_login, _password, fio, dateOfBirth, address, phone, experience, resume, education, salary, position, (int)genderId, (int)militaryRegistrationId, (int)typeOfApplicantId);
            new UserMenu().Show();
            Close();
        }
    }
}
