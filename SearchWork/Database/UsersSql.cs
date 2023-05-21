using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Npgsql;
using System.Data;
using System.Xml;

namespace SearchWork.Database
{
    static class UsersSql
    {
        private static Dictionary<string, object> getDataDictionary(string fio, DateTime dateOfBirth, string address, string phone, string experience, string resume, string education, decimal salary, string position, int genderId, int militaryRegistrationId, int typeOfApplicantId)
        {
            return new Dictionary<string, object>() {
                { "fio", fio },
                { "date_of_birth", dateOfBirth },
                { "address", address },
                { "phone", phone },
                { "experience", experience },
                { "resume", resume },
                { "education", education },
                { "salary", salary },
                { "position", position },
                { "gender_id", genderId },
                { "military_registration_id", militaryRegistrationId },
                { "type_of_applicant_id", typeOfApplicantId }
            };
        }

        static public void create(string login, string password, string fio, DateTime dateOfBirth, string address, string phone, string experience, string resume, string education, decimal salary, string position, int genderId, int militaryRegistrationId, int typeOfApplicantId)
        {
            var userData = getDataDictionary(fio, dateOfBirth, address, phone, experience, resume, education, salary, position, genderId, militaryRegistrationId, typeOfApplicantId);

            var authData = new Dictionary<string, object>()
            {
                { "user_id", Database.add("users", userData) },
                { "login", login },
                { "password", password }
            };

            Database.add("users_auth", authData);

            Database.authLogin = login;
        }

        static public void update(int id, string login, string fio, DateTime dateOfBirth, string address, string phone, string experience, string resume, string education, decimal salary, string position, int genderId, int militaryRegistrationId, int typeOfApplicantId)
        {
            var userData = getDataDictionary(fio, dateOfBirth, address, phone, experience, resume, education, salary, position, genderId, militaryRegistrationId, typeOfApplicantId);

            Database.update("users", id, userData);
        }

        static public Dictionary<string, object> get(string login)
        {
            var reader = Database.sendRequest($"select ua.login, ua.password, u.fio, u.address, u.date_of_birth, u.id, u.phone, u.experience, u.resume, u.education, u.salary, u.position, u.gender_id, u.military_registration_id, u.type_of_applicant_id FROM users_auth ua JOIN users u ON ua.user_id = u.id WHERE ua.login = '{login}'");

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

        static public string init(string login, string password) {
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
                result = "Соискатель не найден";
            }

            return result;
        }
    }
}
