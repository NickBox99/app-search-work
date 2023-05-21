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
    public partial class EmployerResponses : Form
    {
        public EmployerResponses(int vacanciesId)
        {
            InitializeComponent();

            label2.Text += vacanciesId;

            VacanciesSql.renderTable(vacanciesId, dataGridView1);
        }
    }
}
