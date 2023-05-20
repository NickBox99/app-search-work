using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace SearchWork.Database
{
    static class EmployersSql
    {
        public static void renderTable(DataGridView dataGridView)
        {
            Database.renderTable("employers", dataGridView);
        }
        private static Dictionary<string, object> getDataDictionary(string name, string inn, string status, string address, string phone, string additionalInfo)
        {
            return new Dictionary<string, object>() {
                { "name", name },
                { "inn", inn },
                { "status", status },
                { "address", address },
                { "phone", phone },
                { "additional_info", additionalInfo }
            };
        }

        public static void add(string name, string inn, string status, string address, string phone, string additionalInfo)
        {
            Database.add("employers", getDataDictionary(name, inn, status, address, phone, additionalInfo));
        }

        public static void update(int id, string name, string inn, string status, string address, string phone, string additionalInfo)
        {
            Database.update("employers", id, getDataDictionary(name, inn, status, address, phone, additionalInfo));
        }

        public static void delete(int id)
        {
            Database.delete("employers", id);
        }

        public static Dictionary<string, object> get(int id)
        {
            return Database.get("employers", id);
        }
    }
}
