using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

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

            Database.authId = Database.add("users_auth", authData);
        }
    }
}
