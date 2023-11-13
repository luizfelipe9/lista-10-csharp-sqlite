using System;
using Microsoft.Data.Sqlite;

class Persistencia
{
    static void ExecutarPersistencia(string[] args)
    {
        string connectionString = "Data Source=banco.db";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            string createTableCommand = "CREATE TABLE ContaBancaria (Numero INT PRIMARY KEY, Titular TEXT, Saldo REAL)";
            SqliteCommand createTable = new SqliteCommand(createTableCommand, connection);
            createTable.ExecuteNonQuery();

            string insertCommand = "INSERT INTO ContaBancaria (Numero, Titular, Saldo) VALUES (@Numero, @Titular, @Saldo)";
            SqliteCommand insert = new SqliteCommand(insertCommand, connection);
            insert.Parameters.AddWithValue("@Numero", 1234);
            insert.Parameters.AddWithValue("@Titular", "João Silva");
            insert.Parameters.AddWithValue("@Saldo", 1000.0);
            insert.ExecuteNonQuery();

            string selectCommand = "SELECT Numero, Titular, Saldo FROM ContaBancaria";
            SqliteCommand select = new SqliteCommand(selectCommand, connection);
            SqliteDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
                int numero = reader.GetInt32(0);
                string titular = reader.GetString(1);
                double saldo = reader.GetDouble(2);

                Console.WriteLine("Número: {0}, Titular: {1}, Saldo: {2:C2}", numero, titular, saldo);
            }

            reader.Close();

            string updateCommand = "UPDATE ContaBancaria SET Saldo = @Saldo WHERE Numero = @Numero";
            SqliteCommand update = new SqliteCommand(updateCommand, connection);
            update.Parameters.AddWithValue("@Saldo", 2000.0);
            update.Parameters.AddWithValue("@Numero", 1234);
            update.ExecuteNonQuery();

            string deleteCommand = "DELETE FROM ContaBancaria WHERE Numero = @Numero";
            SqliteCommand delete = new SqliteCommand(deleteCommand, connection);
            delete.Parameters.AddWithValue("@Numero", 1234);
            delete.ExecuteNonQuery();
        }
    }
}