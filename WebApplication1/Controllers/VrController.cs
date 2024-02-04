using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class VrController : Controller
    {
        private UserDAL userContext = new UserDAL();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string password)
        {
            List<User> userList = userContext.GetUsers();

            foreach (var user in userList)
            {
                if (user.Password == password)
                {
                    return RedirectToAction("Instructions", "Vr");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        public VrController()
        {

        }


        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Instructions()
        {
            return View();
        }



        public IActionResult Feedback()
        {
            return View();
        }


        public IActionResult FeedbackReview()
        {
            return View();
        }

        public IActionResult PinLogin()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
            //List<User> AccountDetails = GetDetailsForAccount1();

            //return View(AccountDetails);
        }


        //private List<User> GetDetailsForAccount1()
        //{
        //    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OCBC;Integrated Security=True;";

        //    List<User> accountDetails = new List<User>();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        // Query account details specifically for AccountID 1
        //        string query = "SELECT * FROM [OCBC].[dbo].[Account] WHERE [AccountID] = 1";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    User user = new User
        //                    {
        //                        AccountID = Convert.ToInt32(reader["AccountID"]),
        //                        AccountNumber = Convert.ToString(reader["AccountNumber"]),
        //                        Password = Convert.ToString(reader["CardCSV"]), // Assuming CardCSV is the Password field
        //                        Name = Convert.ToString(reader["Name"]),
        //                        Amount = Convert.ToDecimal(reader["Amount"])
        //                    };

        //                    accountDetails.Add(user);
        //                }
        //            }
        //        }
        //    }

        //    return accountDetails;
        //}

        public IActionResult Withdraw()
        {
            return View();
        }

        public IActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepositAmount(decimal Amount)
        {
            return RedirectToAction("Feedback", "Vr");
        }

        public IActionResult WithdrawAmount(string amount)
        {
            return RedirectToAction("Feedback", "Vr");
            //return View();
        }

        public IActionResult TransactionHistory()
        {
            return View();
            //// Retrieve transaction history for the hardcoded account_id 1
            //List<Transaction> transactionHistory = GetTransactionHistoryForAccount1();

            //// Pass the transaction history to the view
            //return View(transactionHistory);
        }


        //private List<Transaction> GetTransactionHistoryForAccount1()

        //{
            
            //        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OCBC;Integrated Security=True;";

            //        List<Transaction> transactionHistory = new List<Transaction>();
            //        using (SqlConnection connection = new SqlConnection(connectionString))
            //        {
            //            connection.Open();

            //            // Query transaction history specifically for account_id 1
            //            string query = "SELECT [transaction_id], [amount], [date], [category_id], [category], [account_id] FROM [OCBC].[dbo].[transactions] WHERE [account_id] = 1";

            //            using (SqlCommand command = new SqlCommand(query, connection))
            //            {
            //                using (SqlDataReader reader = command.ExecuteReader())
            //                {
            //                    while (reader.Read())
            //                    {
            //                        Transaction transaction = new Transaction
            //                        {
            //                            TransactionID = Convert.ToInt32(reader["transaction_id"]),
            //                            transactionamt = Convert.ToDecimal(reader["amount"]),
            //                            transactiondate = Convert.ToDateTime(reader["date"]),
            //                            categoryID = Convert.ToInt32(reader["category_id"]),
            //                            transactioncat = Convert.ToString(reader["category"]),
            //                            account_id = Convert.ToInt32(reader["account_id"]),
            //                        };

            //                        transactionHistory.Add(transaction);
            //                    }
            //                }
            //            }
            //        }

            //        return transactionHistory;
            //    }
        }
    }
