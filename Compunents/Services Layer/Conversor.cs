using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer
{
   public class Conversor
   {
        public static List<T> DataTableToList<T>(DataTable table) where T : new()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var list = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                var obj = new T();
                foreach (var prop in properties)
                {
                    if (table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                    {
                        prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType));
                    }
                }
                list.Add(obj);
            }

            return list;
        }

        public static DataTable ListToDataTable<T>(List<T> list)
        {
            var table = new DataTable();
            if (list == null || !list.Any()) return table;

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }
        public static DataTable SortDataTable(DataTable table, string sortExpression)
        {
            var view = new DataView(table);
            view.Sort = sortExpression;
            return view.ToTable();
        }

        public static string ListToCsv<T>(List<T> list)
        {
            if (list == null || !list.Any()) return string.Empty;

            var sb = new StringBuilder();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            sb.AppendLine(string.Join(",", properties.Select(p => p.Name)));

            foreach (var item in list)
            {
                var line = string.Join(",", properties.Select(p =>
                {
                    var value = p.GetValue(item);
                    return value != null ? value.ToString().Replace(",", " ") : string.Empty;
                }));
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public static List<Dictionary<string, object>> DataTableToDictionaryList(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col] == DBNull.Value ? null : row[col];
                }
                list.Add(dict);
            }

            return list;
        }




    }
}
