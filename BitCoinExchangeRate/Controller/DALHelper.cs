using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BitCoinExchangeRate.Controller
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
          MessageBox.Show(exception.Message);
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

    public static bool WriteToDatabase()
    {
      bool result = false;

      return result;
    }
  }
}
