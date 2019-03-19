using System.Collections.Generic;
using Npgsql;

namespace Actresses.Models
{
    public class Database
    {
        static string connString = Config.host;
        string actressQuery = "SELECT * From actresses";
        string picturesQuery = "SELECT url FROM pictures ORDER BY id ASC";
        List<object> totalActresses;
        List<string> pictureUrls;
        NpgsqlConnection conn = new NpgsqlConnection(connString);

        public Database()
        {
            totalActresses = new List<object>();
            pictureUrls = new List<string>();
        }


        public List<object> getActressData(Actress actress)
        {
            conn.Open();
            var cmd = new NpgsqlCommand(actressQuery, conn);
            
            using (var reader = cmd.ExecuteReader())
            {
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
        }

        public List<string> getPictures()
        {
            conn.Open();
            var cmd = new NpgsqlCommand(picturesQuery, conn);
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

