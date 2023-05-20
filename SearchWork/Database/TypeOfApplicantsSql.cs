using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchWork.Database
{
    static class TypeOfApplicantsSql
    {
        public static void renderTable(DataGridView dataGridView)
        {
            Database.renderTable("type_of_applicants", dataGridView);
        }

        private static Dictionary<string, object> getDataDictionary(string name)
        {
            return new Dictionary<string, object>() {
                { "name", name }
            };
        }

        public static void add(string name)
        {
            Database.add("type_of_applicants", getDataDictionary(name));
        }

        public static void update(int id, string name)
        {
            Database.update("type_of_applicants", id, getDataDictionary(name));
        }

        public static void delete(int id)
        {
            Database.delete("type_of_applicants", id);
        }

        public static Dictionary<string, object> get(int id)
        {
            return Database.get("type_of_applicants", id);
        }
    }
}
