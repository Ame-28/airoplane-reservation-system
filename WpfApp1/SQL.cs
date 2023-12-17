﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;

public class SQL
{
    private readonly string connectionString;

    public SQL()
    {
        connectionString = $"Server={ConfigurationManager.AppSettings["server"]};" +
                            $"Database={ConfigurationManager.AppSettings["database"]};" +
                            $"User ID={ConfigurationManager.AppSettings["userId"]};" +
                            $"Password={ConfigurationManager.AppSettings["password"]};";
    }

    public void insertValues(string tableName, Dictionary<string, object> values)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string columns = string.Join(",", values.Keys);
                string parameters = string.Join(",", values.Keys.Select(key => $"@{key}"));
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    foreach (var kvp in values)
                    {
                        cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting record: {ex.Message}");
            }
        }
    }

    public Dictionary<string, object> readValues(string tableName, string condition)
    {
        Dictionary<string, object> record = new Dictionary<string, object>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName} WHERE {condition} LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read(); // Read the first (and only) row

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                record[columnName] = value;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error reading record: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        return record;
    }

    public List<Dictionary<string, object>> readValues(string tableName, string condition, bool limitToOne = false)
    {
        List<Dictionary<string, object>> records = new List<Dictionary<string, object>>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName} WHERE {condition}";

                if (limitToOne)
                    query += " LIMIT 1";

                query += ";";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) // Iterate through all rows
                        {
                            Dictionary<string, object> record = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                record[columnName] = value;
                            }

                            records.Add(record); // Add the current row to the list
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error reading records: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        return records;
    }


    public void alterValues(string tableName, Dictionary<string, object> newValues, string condition)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Construct the SET part of the UPDATE query
                string setClause = string.Join(",", newValues.Select(kvp => $"{kvp.Key} = @{kvp.Key}"));

                // Construct the full UPDATE query
                string query = $"UPDATE {tableName} SET {setClause} WHERE {condition}";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Add parameters for the new values
                    foreach (var kvp in newValues)
                    {
                        cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating records: {ex.Message}");
            }
        }
    }

    public bool checkValue(string tableName, string columnName, object valueToCheck)
    {
        bool valueExists = false;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Construct the SELECT query to check the existence of the value
                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @ValueToCheck";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Add parameter for the value to check
                    cmd.Parameters.AddWithValue("@ValueToCheck", valueToCheck);

                    // ExecuteScalar returns the number of rows that satisfy the condition
                    int rowCount = Convert.ToInt32(cmd.ExecuteScalar());

                    // If rowCount is greater than 0, the value exists in the database
                    valueExists = rowCount > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking value: {ex.Message}");
            }
        }

        return valueExists;
    }

    public List<Dictionary<string, object>> customQuery(string query)
    {
        List<Dictionary<string, object>> records = new List<Dictionary<string, object>>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) // Iterate through all rows
                        {
                            Dictionary<string, object> record = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                record[columnName] = value;
                            }

                            records.Add(record); // Add the current row to the list
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error executing custom query: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        return records;
    }
}
