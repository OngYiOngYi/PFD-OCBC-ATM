using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;
using WebApplication1.Models;

using System.Data.SqlClient;

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
	}
}
