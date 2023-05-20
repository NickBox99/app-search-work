using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SearchWork.Database
{
    static class GendersSql
    {
        public static void renderTable(DataGridView dataGridView) {
            Database.renderTable("genders", dataGridView);
        }

        private static Dictionary<string, object>  getDataDictionary(string name)
        {
            return new Dictionary<string, object>() {
                { "name", name }
            };
        }

        public static void add(string name) {
            Database.add("genders", getDataDictionary(name));
        }

        public static void update(int id, string name) {
            Database.update("genders", id, getDataDictionary(name));
        }

        public static void delete(int id) {
            Database.delete("genders", id);
        }

        public static Dictionary<string, object> get(int id) {
            return Database.get("genders", id);
        }
    }
}
