using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds_SelfService.Dal
{
    internal class Database
    {
        readonly private string connectionString = @"Data Source=(local);Initial Catalog=McDonalds;Integrated Security=True";

        public string[,] GetProducts(string productType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"Select{productType}", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        List<string> productName = new List<string>();
                        List<string> price = new List<string>();
                        while (reader.Read())
                        {
                            productName.Add(reader["ProductName"].ToString());
                            price.Add(reader["Price"].ToString());
                        }

                        string[,] burgers = new string[productName.Count, 2];
                        for (int i = 0; i < productName.Count; i++)
                        {
                            burgers[i, 0] = productName[i];
                            burgers[i, 1] = price[i];
                        }
                        return burgers;
                    }
                }

            }
        }

        public string GetProductName(string productType, byte productNum)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"Select{productType}Name", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BurgerID", productNum);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        string productName = "";
                        while (reader.Read())
                        {
                            productName = reader[0].ToString();
                        }
                        return productName;
                    }
                }

            }
        }

        public string[] GetProductIngredients(string productType, string productName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"Select{productType}Ingredients", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductName", productName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> ingredients = new List<string>();
                        while (reader.Read())
                        {
                            ingredients.Add(reader[0].ToString());
                            ingredients.Add(reader[1].ToString());
                            ingredients.Add(reader[2].ToString());
                            ingredients.Add(reader[3].ToString());
                            ingredients.Add(reader[4].ToString());
                            ingredients.Add(reader[5].ToString());
                            ingredients.Add(reader[6].ToString());
                        }
                        return ingredients.ToArray();
                    }
                }

            }
        }
    }
}