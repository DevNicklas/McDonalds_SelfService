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

        /// <summary>
        /// Gets all products within a table and returns it
        /// </summary>
        /// <param name="productType">category/type of product</param>
        /// <returns>A 2-dimensional string array, with all the products from the specified category</returns>
        public string[,] GetProducts(string productType)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Opens the connection, if possible, if not then the program crashes
                // This should be fixed, maybe with a try-catch
                connection.Open();

                // Executes the stored procedure
                using (SqlCommand command = new SqlCommand($"Select{productType}", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Reads the data from the queue
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        // Puts the data in two seperated string lists
                        List<string> productName = new List<string>();
                        List<string> price = new List<string>();
                        while (reader.Read())
                        {
                            productName.Add(reader["ProductName"].ToString());
                            price.Add(reader["Price"].ToString());
                        }

                        // Takes all the data from the two seperated string lists and
                        // puts them inside one 2-dimensinal array and returns the value
                        string[,] burgers = new string[productName.Count, 2];
                        for (int i = 0; i < productName.Count; i++)
                        {
                            // Product Name is at column 0
                            // Product Price is at column 1
                            burgers[i, 0] = productName[i];
                            burgers[i, 1] = price[i];
                        }
                        return burgers;
                    }
                }

            }
        }

        /// <summary>
        /// Gets a product name by using the product number
        /// </summary>
        /// <param name="productType">type of product</param>
        /// <param name="productNum">number of product</param>
        /// <returns>A string which is the product name</returns>
        public string GetProductName(string productType, byte productNum)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Opens the connection, if possible, if not then the program crashes
                connection.Open();

                // Executes the stored procedure
                using (SqlCommand command = new SqlCommand($"Select{productType}Name", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // ID or Product number of the product, which is used to find
                    // the correct product name associated with that ID
                    // At the moment only burgers work
                    command.Parameters.AddWithValue("@BurgerID", productNum);

                    // Reads the data from the queue
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        // Gets the product name and returns it
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

        /// <summary>
        /// Gets the all the product ingredients within a product
        /// </summary>
        /// <param name="productType">type of product</param>
        /// <param name="productName">name of product</param>
        /// <returns>A string array with all ingredients within a product</returns>
        public string[] GetProductIngredients(string productType, string productName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Opens the connection, if possible, if not then the program crashes
                connection.Open();

                // Executes the stored procedure
                using (SqlCommand command = new SqlCommand($"Select{productType}Ingredients", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Product name which is used to find the correct ingredients associated
                    command.Parameters.AddWithValue("@ProductName", productName);

                    // Reads the data from the queue
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Adds every ingredient to a string list and returns it as an string array
                        List<string> ingredients = new List<string>();
                        while (reader.Read())
                        {
                            // This is only for burgers at the moment
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