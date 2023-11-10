using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;
using WebApplication1.Models;

using System.Data.SqlClient;
using System.Runtime.CompilerServices;

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
	}
}
