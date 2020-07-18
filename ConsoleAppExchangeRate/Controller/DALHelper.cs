using System;
using System.Data.SqlClient;

namespace ConsoleAppExchangeRate.Controller
{
  public static class DALHelper
  {
    public static string GetConnexionString()
    {
      return "Data Source=DESKTOP-MSI;Initial Catalog=CryptoCurrencies;Integrated Security=True";
    }

    public static string GetLatestDate()
    {
      string result = string.Empty;
      //string sqlRequest = "SELECT TOP(1) * FROM BitCoin";
      string connectionString = GetConnexionString();
      string query = "SELECT TOP(1) Date FROM BitCoin order by date DESC";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        try
        {
          connection.Open();
          var queryResult = command.ExecuteScalar();
          if (queryResult == null)
          {
            result = string.Empty;
          }
          else
          {
            result = queryResult.ToString();
          }
        }
        catch (Exception exception)
        {
          Console.WriteLine(exception.Message);
        }
        finally
        {
          connection.Close();
        }
      }

      if (result == null)
      {
        result = string.Empty;
      }

      return result;
    }

    public static bool WriteToDatabase(DateTime requestDate, double euro, double dollar)
    {
      bool result = false;
      using (SqlConnection connection = new SqlConnection(GetConnexionString()))
      {
        string query = "INSERT INTO [dbo].[BitCoin] ([Date], [RateEuros], [RateDollar]) VALUES(@theDate, @rateEuro, @ratedollar)";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@theDate", requestDate);
          command.Parameters.AddWithValue("@rateEuro", euro);
          command.Parameters.AddWithValue("@ratedollar", dollar);

          connection.Open();
          var QueryResult = command.ExecuteNonQuery();

          // Check Error
          if (QueryResult < 0)
          {
            //var errorMessage = "Error inserting data into Database!";
            result = false;
          }
          else
          {
            result = true;
          }
        }
      }

      return result;
    }
  }
}
