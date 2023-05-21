using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Npgsql;
using System.Data;

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

        static public NpgsqlDataReader get(string login)
        {
            return Database.sendRequest($"select * from users_auth WHERE login = '{login}'");
        }

        static public string init(string login, string password) {
            var result = "";

            var user = get(login);

            if (user.Read())
            {
                if (user.GetString(3) != password)
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
