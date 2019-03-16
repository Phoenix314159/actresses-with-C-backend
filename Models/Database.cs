using System.Collections.Generic;
using Npgsql;

namespace Actresses.Models
{
    public class Database
    {
        private static string connString = Config.host;
        private string actressQuery = "SELECT * From actresses";
        private string picturesQuery = "SELECT url FROM pictures ORDER BY id ASC";
        private NpgsqlConnection conn = new NpgsqlConnection(connString);

        public List<object> getActressData(Actress actress)
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(actressQuery, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<object> totalActresses = new List<object>();

            while (reader.Read())
            {
                actress.Id = reader.GetInt32(0);
                actress.Year = reader.GetString(1);
                actress.Name = reader.GetString(2);
                actress.Movie = reader.GetString(3);
                totalActresses.Add(actress);
            }
            reader.Close();
            conn.Close();
            return totalActresses;
        }
        public List<string> getPictures()
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(picturesQuery, conn);
            List<string> pictureUrls = new List<string>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    pictureUrls.Add(reader.GetString(0));
                }
            }
            conn.Close();
            return pictureUrls;
        }
    }
}

