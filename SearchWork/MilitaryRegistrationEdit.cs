using SearchWork.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchWork
{
    public partial class MilitaryRegistrationEdit : Form
    {
        int _id;
        public MilitaryRegistrationEdit(int id)
        {
            InitializeComponent();
            _id = id;

            var result = GendersSql.get(id);
            comboBox1.Text = (string)result["name"];
            _id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = comboBox1.Text;

            if (name.Length == 0)
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            MilitaryRegistrationsSql.update(_id, name);
            MessageBox.Show("Выполнено, обновите таблицу");
            Close();
        }
    }
}
