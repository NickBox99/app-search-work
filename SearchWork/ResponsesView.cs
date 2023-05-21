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
    public partial class ResponsesView : Form
    {
        public ResponsesView(int vacaniesId)
        {
            InitializeComponent();

            var vacanies = VacanciesSql.getFull(vacaniesId);

            label14.Text = vacanies["salary"].ToString();
            label15.Text = $"{vacanies["min_age"]} - {vacanies["max_age"]}";
            label16.Text = (string)vacanies["requirements"];
            label17.Text = (string)vacanies["work_schedule"];
            label18.Text = (string)vacanies["additional_info"];

            label19.Text = (string)vacanies["name"];
            label20.Text = (string)vacanies["inn"];
            label21.Text = (string)vacanies["status"];
            label22.Text = (string)vacanies["address"];
            label23.Text = (string)vacanies["phone"];
            label24.Text = (string)vacanies["additional_info_employer"];
        }
    }
}
