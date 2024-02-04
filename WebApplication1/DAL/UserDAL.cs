using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;
using WebApplication1.Models;

using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;

namespace WebApplication1.DAL
{
    public class UserDAL
    {

		private IConfiguration Configuration { get; }
		private SqlConnection conn;
		//Constructor
		public UserDAL()
		{
			//Read ConnectionString from appsettings.json file
			var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json");
			Configuration = builder.Build();
			string strConn = Configuration.GetConnectionString(
			"OCBCConnectionString");
			//Instantiate a SqlConnection object with the
			//Connection String read.
			conn = new SqlConnection(strConn);
		}

		public List<User> GetUsers()
		{
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = @"SELECT * FROM Account";
			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader();
			List<User> userList = new List<User>();
			while (reader.Read())
			{
				userList.Add(
				new User
				{
					AccountID = reader.GetInt32(0),
					Name = reader.GetString(1),
					AccountNumber = reader.GetString(2),
					Password = reader.GetString(3),
					Amount = reader.GetDecimal(4),
				}
				) ; 
			}
			reader.Close();
			conn.Close();
			return userList;
		}

		//public int Withdraw(User user, decimal amount)
		//{
		//	SqlCommand cmd = conn.CreateCommand();
		//	cmd.CommandText = @"Update Account SET Amount=@amount
		//						WHERE AccountID=@userid";
		//	cmd.Parameters.AddWithValue("@amount", user.Amount);
		//	cmd.Parameters.AddWithValue("@userid", user.AccountID);
		//	conn.Open();
		//	cmd.ExecuteReader();
		//	return cmd.ExecuteNonQuery();

		//}

		public int Withdraw(User user, decimal amount)
		{
			using (SqlCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = @"UPDATE Account SET Amount=@amount WHERE AccountID=@userid";
				cmd.Parameters.AddWithValue("@amount", amount);  // Use the provided 'amount' parameter
				cmd.Parameters.AddWithValue("@userid", user.AccountID);
				conn.Open();
				int rowsAffected = cmd.ExecuteNonQuery();

				// Close the connection
				conn.Close();
				return rowsAffected;
			}
		}

		public int Deposit(User user)
		{
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = @"Update Account SET Amount=@amount
								WHERE AccountID=@userid";
			cmd.Parameters.AddWithValue("@amount", user.Amount);
			cmd.Parameters.AddWithValue("@userid", user.AccountID);
			conn.Open();
			int rowsAffected = cmd.ExecuteNonQuery();

			// Close the connection
			conn.Close();
			return rowsAffected;
		}

        public List<Transaction> GetTransactions(int? user, int month, int year)
        {
            List<Transaction> transactionList = new List<Transaction>();
            conn.Open();
            string query = @"SELECT * FROM Transactions WHERE account_id = @account_id AND MONTH(date) = @selectedMonth 
                     AND YEAR(date) = @selectedYear ORDER BY date DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@account_id", user);
            cmd.Parameters.AddWithValue("@selectedmonth", month);
            cmd.Parameters.AddWithValue("@selectedyear", year);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Transaction transaction = new Transaction
                {
                    TransactionID = reader.GetInt32(0),
                    transactionamt = reader.GetDecimal(1),
                    transactiondate = reader.GetDateTime(2),
                    categoryID = reader.GetInt32(3),
                    transactioncat = reader.GetString(4),
                    account_id = reader.GetInt32(5),
                };

                transactionList.Add(transaction);
            }

            reader.Close();
            conn.Close();
            return transactionList;
        }

        public int AddHistory(Transaction transaction)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"
				DECLARE @LatestTransactionID INT;
				SELECT @LatestTransactionID = ISNULL(MAX(Transaction_ID), 0) FROM Transactions;

				INSERT INTO Transactions (Transaction_ID, Amount, Date, Category_ID, Category, Account_ID)
				VALUES(@LatestTransactionID + 1, @amount, @date, @categoryid, @category, @accountid);

				SELECT @LatestTransactionID + 1 AS NewTransactionID;";
            cmd.Parameters.AddWithValue("@amount", transaction.transactionamt);
            cmd.Parameters.AddWithValue("@date", transaction.transactiondate);
            cmd.Parameters.AddWithValue("@categoryid", transaction.categoryID);
            cmd.Parameters.AddWithValue("@category", transaction.transactioncat);
            cmd.Parameters.AddWithValue("@accountid", transaction.account_id);

            conn.Open();
            transaction.TransactionID = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return transaction.TransactionID;
        }
    }
}

