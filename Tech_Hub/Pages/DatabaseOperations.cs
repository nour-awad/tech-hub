using System.Data;
using System.Data.SqlClient;
namespace Tech_Hub.Pages
{
    public class DatabaseOperations
    {
        private static string connectionString = "Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True";
        private SqlConnection con = new SqlConnection(connectionString);

        public DatabaseOperations()
        {
            con.ConnectionString = connectionString;
        }

        // read any table
        public DataTable ReadTable(string table)
        {
            DataTable dt = new DataTable();
            string query = $"select * from {table}";
            SqlCommand cmd = new SqlCommand(query, con);
            
            try
            {
                con.Open();
                dt.Load(cmd.ExecuteReader());

            }
            catch (SqlException err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public static void InsertReviewData(string con, int reviewId, int rating, DateTime reviewDate, string reviewText, int customerId, int productId)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Review (ReviewID, Rating, ReviewDate, ReviewText, CustomerID, ProductID) " +
                                   "VALUES (@ReviewID, @Rating, @ReviewDate, @ReviewText, @CustomerID, @ProductID)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReviewID", reviewId);
                        command.Parameters.AddWithValue("@Rating", rating);
                        command.Parameters.AddWithValue("@ReviewDate", reviewDate);
                        command.Parameters.AddWithValue("@ReviewText", reviewText);
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        command.Parameters.AddWithValue("@ProductID", productId);

                        command.ExecuteNonQuery();

                        Console.WriteLine("Review data inserted successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public static void InsertCartData(string con, int cartId, int customerId, int productId, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Cart (CartID, CustomerID, ProductID, Quantity) " +
                                   "VALUES (@CartID, @CustomerID, @ProductID, @Quantity)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CartID", cartId);
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        command.Parameters.AddWithValue("@ProductID", productId);
                        command.Parameters.AddWithValue("@Quantity", quantity);

                        command.ExecuteNonQuery();

                        Console.WriteLine("Cart data inserted successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public static void InsertCustomerData(string con, string firstName, string lastName, string billingAddress, string shippingAddress, string phoneNumber, string email)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Customer (FirstName, LastName, BillingAddress, ShippingAddress, PhoneNumber, Email) " +
                                   "VALUES (@FirstName, @LastName, @BillingAddress, @ShippingAddress, @PhoneNumber, @Email)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@BillingAddress", billingAddress);
                        command.Parameters.AddWithValue("@ShippingAddress", shippingAddress);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", email);

                        command.ExecuteNonQuery();

                        Console.WriteLine("Customer data inserted successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }


        public static void DeleteData(string con,string tableName, string columnName, string inputValue)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();

                    string query = $"DELETE FROM {tableName} WHERE {columnName} = @InputValue";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InputValue", inputValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No matching data found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public static void UpdateData(string tableName, string columnName, string newValue, string oldValue)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.Open();

                    string query = $"UPDATE {tableName} SET {columnName} = @NewValue WHERE {columnName} = @OldValue";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewValue", newValue);
                        command.Parameters.AddWithValue("@OldValue", oldValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No matching data found for the update.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public static void RetrieveData(string tableName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT * FROM {tableName}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write(reader[i] + "\t");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No data found in the table.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }


		public static bool SearchData(string con, string tableName, string columnName, string search_Value)
		{
			try
			{
                using(SqlConnection connection = new SqlConnection(con))
                {
					connection.Open();

					string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @searchValue";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@searchValue", search_Value);

						Console.WriteLine("Executing query: " + command.CommandText);

						int count = (int)command.ExecuteScalar();

						return count > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
				return false;
			}			
		}
	}
}
