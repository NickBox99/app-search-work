using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Xml;

namespace SearchWork.Database
{
    static class VacanciesSql
    {
        private static Dictionary<string, object> getDataDictionary(int employerId, decimal salary, int minAge, int maxAge, string requirements, string workSchedule, string vacancyStatus, string additionalInfo)
        {
            return new Dictionary<string, object>() {
                { "employer_id", employerId },
                { "salary", salary },
                { "min_age", minAge },
                { "max_age", maxAge },
                { "requirements", requirements },
                { "work_schedule", workSchedule },
                { "vacancy_status", vacancyStatus },
                { "additional_info", additionalInfo }
            };
        }

        public static void add(int employerId, decimal salary, int minAge, int maxAge, string requirements, string workSchedule, string vacancyStatus, string additionalInfo) {
            Database.add("vacancies", getDataDictionary(employerId, Convert.ToInt32(salary), minAge, maxAge, requirements, workSchedule, vacancyStatus, additionalInfo));
        }

        public static void delete(int id)
        {
            Database.delete("vacancies", id);
        }

        public static void renderTable(int vacanciesId, DataGridView dataGridView)
        {
            var result = Database.sendRequest($"select t.name AS type_of_applicant, mil.name AS military_registration, gen.name AS gender, u.fio, u.date_of_birth, u.address, u.phone, u.experience, u.resume, u.education, u.salary, u.position FROM responses res JOIN users u ON u.id = res.user_id JOIN genders gen ON gen.id = u.gender_id JOIN military_registrations mil ON mil.id = u.military_registration_id JOIN type_of_applicants t ON t.id = u.type_of_applicant_id WHERE res.vacancies_id = {vacanciesId}");

            Database.renderTable(result, dataGridView);
        }

        public static void renderTable(DataGridView dataGridView, int employerId)
        {
            var result = Database.sendRequest($"select * FROM vacancies WHERE employer_id = {employerId}");

            Database.renderTable(result, dataGridView);
        }

        public static void renderTable(DataGridView dataGridView)
        {
            var result = Database.sendRequest($"select vac.id, vac.salary, vac.min_age, vac.max_age, vac.requirements, vac.work_schedule, e.name FROM vacancies vac JOIN employers e ON vac.employer_id = e.id WHERE vac.vacancy_status = 'активна' AND NOT EXISTS (SELECT 1 FROM responses res WHERE vac.id = res.vacancies_id)");

            Database.renderTable(result, dataGridView);
        }

        public static void update(int id, int employerId, decimal salary, int minAge, int maxAge, string requirements, string workSchedule, string vacancyStatus, string additionalInfo)
        {
            Database.update("vacancies", id, getDataDictionary(employerId, Convert.ToInt32(salary), minAge, maxAge, requirements, workSchedule, vacancyStatus, additionalInfo));
        }

        public static Dictionary<string, object> get(int id)
        {
            return Database.get("vacancies", id);
        }

        public static Dictionary<string, object> getFull(int id)
        {
            var reader = Database.sendRequest($"select vac.salary, vac.min_age, vac.max_age, vac.requirements, vac.work_schedule, vac.additional_info, e.name, e.inn, e.status, e.address, e.phone, e.additional_info AS additional_info_employer FROM vacancies vac JOIN employers e ON vac.employer_id = e.id WHERE vac.id = {id};");

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

        public static void sendResponses(int vacanciesId, int userId) {
            Database.add("responses", new Dictionary<string, object>() {
                { "vacancies_id", vacanciesId },
                { "user_id", userId }
            });
        }
    }
}
