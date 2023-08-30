using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds_SelfService.Dal
{
    internal class Database
    {
        readonly private string connectionString = @"Data Source=(local);Initial Catalog=McDonalds;Integrated Security=True";

        public string[,] GetBurgers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProductName, Price FROM Burgers;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {

                        List<string> productName = new List<string>();
                        List<string> price = new List<string>();
                        while (reader.Read())
                        {
                            productName.Add(reader["ProductName"].ToString());
                            price.Add(reader["Price"].ToString());
                        }

                        string[,] burgers = new string[5, 2];
                        for(int i = 0; i < 5; i++)
                        {
                            burgers[i,0] = productName[i];
                            burgers[i,1] = price[i];
                        }
                        return burgers;
                    }
                }

            }
        }
    }
}
