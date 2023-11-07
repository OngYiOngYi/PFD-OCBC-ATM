using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

		private List<User> users = new List<User>
		{
			new User { Username = "user1", Password = "password1", Name = "Itsuki Nakano" },
			new User { Username = "user2", Password = "password2" , Name = "Nino Nakano"},
			new User { Username = "user3", Password = "1234567890" , Name = "Miku Nakano"}
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
			User user = users.Find(u => u.Username == username && u.Password == password);

			if (user != null)
			{
				// Simulating authentication using TempData, can be replaced with authentication mechanisms like Identity in real applications
				TempData["LoggedInUser"] = user.Name;
				return RedirectToAction("Home", "Home"); // Redirect to the home page
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid username or password. Please try again.";
				return RedirectToAction("Index"); // Return the view with an error message
			}
		}

        public IActionResult EyeLogin()
        {
            User user1 = new User();
            user1.Username = "7891234560";
            user1.Password = "159";
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
        public IActionResult SubmitAmount(int amount) 
        {
            if (amount > 0)
            {
                TempData["SuccessMsg"] = "Successful Deposit";

            }

            else
            {
                TempData["ErrorMsg"] = "Please enter valid amount";
            }

            return RedirectToAction("Deposit");
        }

        public IActionResult WithdrawAmount(int amount)
        {
			if (amount > 0)
			{
				TempData["WSuccessMsg"] = "Successful withdraw of $" + amount;
			}

			else
			{
				TempData["WErrorMsg"] = "Please enter valid amount";
			}
            return RedirectToAction("Feedback");
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