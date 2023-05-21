using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Npgsql;

namespace SearchWork.Database
{
    static class Database
    {
        static NpgsqlConnection npgsqlConnection = null;
        static NpgsqlCommand npgsqlCommand = null;
        static NpgsqlDataReader npgsqlDataReader = null;
        static public string authLogin;

        public static NpgsqlDataReader sendRequest(string query) {

            if (npgsqlConnection != null)
            {
                npgsqlCommand.Dispose();
                npgsqlConnection.Close();
            }

            npgsqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Database=SearchWork;User Id=postgres;Password=root;");

            npgsqlConnection.Open();

            npgsqlCommand = new NpgsqlCommand();

            npgsqlCommand.Connection = npgsqlConnection;
            npgsqlCommand.CommandType = CommandType.Text;
            npgsqlCommand.CommandText = query;

            npgsqlDataReader = npgsqlCommand.ExecuteReader();
            
            return npgsqlDataReader;
        }

        public static void renderTable(string nameTable, DataGridView dataGridView)
        {
            var result = sendRequest($"select * from {nameTable}");

            if (result.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(result);

                dataGridView.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = dataGridView.Rows.Add();

                    foreach (DataColumn column in dt.Columns)
                    {
                        string columnName = column.ColumnName;
                        object value = row[columnName];

                        if (dataGridView.Columns.Contains(columnName))
                        {
                            int columnIndex = dataGridView.Columns[columnName].Index;
                            dataGridView.Rows[rowIndex].Cells[columnIndex].Value = value;
                        }
                    }
                }

                dataGridView.Sort(dataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        public static void renderCombobox(ComboBox comboBox, string nameTable, string displayKey)
        {
            List<KeyValueItem> items = new List<KeyValueItem>();

            var result = sendRequest($"select id, {displayKey} from {nameTable}");

            if (result.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(result);

                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new KeyValueItem((int)row[0], (string)row[1]));
                }
            }

            comboBox.DataSource = items;
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static Dictionary<string, object> get(string nameTable, int id) {
            var reader = sendRequest($"select * from {nameTable} WHERE id = {id};");

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

        public static int add(string nameTable, Dictionary<string, object> data) {
            var keysStr = "";
            var valueStr = "";
            var size = data.Count;
            var lastIndex = size - 1;

            for (int i = 0; i < size; i++) {
                var key = data.Keys.ElementAt(i);
                object value = data[key];

                valueStr += (value is string || value is DateTime) ? $"'{value}'" : value;
                keysStr += key;

                if (i < lastIndex)
                {
                    valueStr += ", ";
                    keysStr += ", ";
                }
            }

            sendRequest($"INSERT INTO {nameTable} ({keysStr}) VALUES ({valueStr});");

            npgsqlDataReader.Close();

            var command = new NpgsqlCommand();
            command.Connection = npgsqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT LASTVAL();";

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static void update(string nameTable, int id, Dictionary<string, object> data) {
            var query = "";
            var size = data.Count;
            var lastIndex = size - 1;

            for (int i = 0; i < size; i++)
            {
                var key = data.Keys.ElementAt(i);
                object value = data[key];

                query += $"{ key } = " + (value is string ? $"'{value}'" : value);


                if (i < lastIndex)
                {
                    query += ", ";
                }
            }

            sendRequest($"UPDATE { nameTable } SET { query } WHERE id = { id };");
        }

        public static void delete(string nameTable, int id) {
            sendRequest($"DELETE FROM { nameTable } WHERE id = { id };");
        }
    }
}
