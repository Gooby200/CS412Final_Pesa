using MySql.Data.MySqlClient;

namespace CS412Final_Pesa.Helpers {
    public static class Extensions {
        public static string GetNullString(this MySqlDataReader reader, string colName) {
            int colIndex = reader.GetOrdinal(colName);
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return null;
        }
    }
}