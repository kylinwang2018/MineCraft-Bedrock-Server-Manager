using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MineCraft_Bedrock_Server_Manager.Data
{
    public static class SQLiteHelper
    {
        public static IConfiguration _configuration;
        /// <summary>
        /// Executes the query using the given System.Data.SqlClient.SqlCommand on database
        ///     specified by connection string name.
        ///     Connection string is loaded from App.config.
        ///     Returns number of rows affected.
        /// </summary>
        /// <param name="cmd">An System.Data.SqlClient.SqlCommand containing the query (CommandText).</param>
        /// <param name="connectionStringName">Name of connection string to load from App.config.</param>
        /// <returns>The number of rows effacted</returns>
        public static async Task<int> ExecuteNonQueryFromSQLAsync(SqliteCommand cmd, string connectionStringName)
        {
            // Get connection string from Web.config
            string conStr = _configuration.GetConnectionString(connectionStringName).ToString();

            int result = 0;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqliteConnection connection = new SqliteConnection(conStr))
            {
                // Open the connection in a try/catch block.
                // Execute the query, writing the result
                try
                {
                    cmd.Connection = connection;
                    connection.Open();
                    result = await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        /// <summary>
        /// Similar to ExecuteNonQueryFromSQL, but the affected Id is returned.
        /// </summary>
        /// <param name="cmd">An System.Data.SqlClient.SqlCommand containing the query (CommandText).</param>
        /// <param name="connectionStringName">Name of connection string to load from App.config.</param>
        /// <returns>The identity number</returns>
        public static async Task<int> ExecuteScalarFromSQLAsync(SqliteCommand cmd, string connectionStringName)
        {
            // Get connection string from Web.config
            string conStr = _configuration.GetConnectionString(connectionStringName).ToString();

            int modified;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqliteConnection connection = new SqliteConnection(conStr))
            {
                // Open the connection in a try/catch block.
                // Execute the query, writing the result
                try
                {
                    cmd.Connection = connection;
                    connection.Open();
                    modified = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return modified;
        }

        /// <summary>Executes the query using the given System.Data.SqlClient.SqlCommand on database
        ///     Connection string is loaded from App.config.
        ///     Template is a class which the result data will be filled into. The query should
        ///     return only one result set.
        ///     Returns a list of type T.
        /// </summary>
        /// <param name="cmd">The query to run on the database.</param>
        /// <param name="connectionStringName">Name of connection string to load from App.config.</param>
        public static async Task<List<T>> GetDataTableFromSQLAsync<T>(SqliteCommand cmd, string connectionStringName)
        {
            // Get connection string from Web.config
            string conStr = _configuration.GetConnectionString(connectionStringName).ToString();

            // Create a new Collection of target class objects
            List<T> results = new List<T>();
            var properties = typeof(T).GetProperties();


            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqliteConnection connection = new SqliteConnection(conStr))
            {

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                try
                {
                    cmd.Connection = connection;
                    connection.Open();
                    using (SqliteDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var item = Activator.CreateInstance<T>();
                            foreach (var property in properties)
                            {
                                try
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                                    {
                                        Type convertTo = Nullable.GetUnderlyingType(
                                            property.PropertyType) ?? property.PropertyType;
                                        property.SetValue(item, Convert.ChangeType(
                                            reader[property.Name], convertTo), null);
                                    }
                                }
                                catch
                                {
                                    // Which means that no property name as same as it in the Db table
                                    // so, do nothing, leave it as null or default.
                                    property.SetValue(item, default);
                                }
                            }
                            results.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return results;
        }
    }
}
