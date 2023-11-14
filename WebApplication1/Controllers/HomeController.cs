using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private UserDAL userContext = new UserDAL();

		private List<User> users = new List<User>
		{
			new User { AccountID = 100, Name="Itsuki Nakano", AccountNumber="12345678", Password="123456",Amount=10000 },
		};

		public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }


		[HttpPost]
		public IActionResult Login(string username, string password)
		{
			//User user = users.Find(u => u.Password == password);

			//if (user != null)
			//{
			//	// Simulating authentication using TempData, can be replaced with authentication mechanisms like Identity in real applications
			//	TempData["LoggedInUser"] = user.Name;
			//	return RedirectToAction("Home", "Home"); // Redirect to the home page
			//}
			//else
			//{
			//	ViewBag.ErrorMessage = "Invalid username or password. Please try again.";
			//	return RedirectToAction("Index"); // Return the view with an error message
			//}

            List<User> userList = userContext.GetUsers();

            foreach (var user in userList)
            {
                if (user.Password == password)
                {
                    TempData["LoggedInUSer"] = user.Name;
                    HttpContext.Session.SetInt32("UserID", user.AccountID);
                    return RedirectToAction("Home", "Home");
                }
            }
            return RedirectToAction("Index");
		}

        public IActionResult EyeLogin()
        {
            User user1 = new User();
            user1.AccountNumber = "7891234560";
            user1.Password = "159521";
            user1.Name = "Isaac Uesugi";
            TempData["LoggedInUser"] = user1.Name;
            return View();
        }

        [HttpPost]
        public IActionResult EyeLoginValidate()
        {
            return Json(new { success = true });
        }

	    public IActionResult Home()
        {
            return View(); 
        }  


        public IActionResult Withdraw()
        {
            return View();
        }

        public IActionResult Deposit()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> DepositAmount(decimal Amount)
		{
			List<User> userList = userContext.GetUsers();

			foreach (var user in userList)
			{
				if (user.AccountID == HttpContext.Session.GetInt32("UserID"))
				{
					if (Amount <= 0)
					{
						TempData["ErrorMsg"] = "You cannot deposit a non-positive amount";
					}
					else
					{


						decimal newAmount = user.Amount + Amount;
						user.Amount = newAmount;
						userContext.Deposit(user);

						TempData["DotMessage"] = ""; 
						TempData["SuccessMsg"] = "Successful Deposit";
						await Task.Delay(6000);
						return RedirectToAction("Feedback");
					}
				}
			}

			TempData["ErrorMsg"] = "User not found";
            return View();
		}

		public IActionResult WithdrawAmount(int amount)
        {

			List<User> userList = userContext.GetUsers();

			foreach (var user in userList)
			{
				if (user.AccountID == HttpContext.Session.GetInt32("UserID"))
				{
					if (user.Amount - amount < 0)
                    {
                        TempData["ErrorMsg"] = "There is not enough amount to withdraw";
                        return View();
                    }

                    else if (user.Amount - amount > 0)
                    {
                        decimal amt = user.Amount;
                        decimal newamt = amt - amount;
                        userContext.Withdraw(user, newamt);
                        TempData["SuccessMsg"] = "Successful withdraw";
						return RedirectToAction("Feedback");
					}

				}
			}
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
    }
}