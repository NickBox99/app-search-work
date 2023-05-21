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

        public static void delete(int id)
        {
            Database.delete("employers", id);
        }

        public static Dictionary<string, object> get(int id)
        {
            return Database.get("employers", id);
        }

        public static void update(int id, string name, string inn, string status, string address, string phone, string additionalInfo)
        {
            Database.update("employers", id, getDataDictionary(name, inn, status, address, phone, additionalInfo));
        }

        static public void create(string login, string password, string name, string inn, string status, string address, string phone, string additionalInfo)
        {
            var userData = getDataDictionary(name, inn, status, address, phone, additionalInfo);

            var authData = new Dictionary<string, object>()
            {
                { "employer_id", Database.add("employers", userData) },
                { "login", login },
                { "password", password }
            };

            Database.add("employers_auth", authData);

            Database.authLogin = login;
        }
        static public Dictionary<string, object> get(string login)
        {
            var reader = Database.sendRequest($"select ea.login, ea.password, e.id, e.name, e.inn, e.status, e.address, e.phone, e.additional_info FROM employers_auth ea JOIN employers e ON ea.employer_id = e.id WHERE ea.login = '{login}'");

            Dictionary<string, object> data = new Dictionary<string, object>();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = reader.GetName(i);
                    object value = reader.GetValue(i);

                    if (value != null && value != DBNull.Value)
                    {
                        data.Add(columnName, value);
                    }
                }
            }

            return data;
        }

        static public string init(string login, string password)
        {
            var result = "";

            var user = get(login);

            if (user.Count != 0)
            {
                if ((string)user["password"] != password)
                {
                    result = "Пароль неверный";
                }
            }
            else
            {
                result = "Работодатель не найден";
            }

            return result;
        }
    }
}
