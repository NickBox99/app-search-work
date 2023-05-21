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
    public partial class UserRegistration : Form
    {
        string _login;
        string _password;
        public UserRegistration(string login, string password)
        {
            InitializeComponent();
            _login = login;
            _password = password;
        }
    }
}
