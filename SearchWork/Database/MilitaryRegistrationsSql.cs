using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchWork.Database
{
    static class MilitaryRegistrationsSql
    {
        public static void renderTable(DataGridView dataGridView)
        {
            Database.renderTable("military_registrations", dataGridView);
        }

        private static Dictionary<string, object> getDataDictionary(string name)
        {
            return new Dictionary<string, object>() {
                { "name", name }
            };
        }

        public static void add(string name)
        {
            Database.add("military_registrations", getDataDictionary(name));
        }

        public static void update(int id, string name)
        {
            Database.update("military_registrations", id, getDataDictionary(name));
        }

        public static void delete(int id)
        {
            Database.delete("military_registrations", id);
        }

        public static Dictionary<string, object> get(int id)
        {
            return Database.get("military_registrations", id);
        }
    }
}
