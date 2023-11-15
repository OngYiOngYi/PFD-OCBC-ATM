using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class VrController : Controller
    {

		public VrController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string password)
        {
            if (password == "654321")
            {
                return RedirectToAction("Home", "Vr");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Home()
        {
            return View(); 
        }  


        public IActionResult Withdraw()
        {
            return View();
        }

        public IActionResult WithdrawOA()
        {
            return View();
        }

        public IActionResult Deposit()
        {
            return View();
        }

		[HttpPost]
		public IActionResult DepositAmount()
		{
            return View();
		}

        //      [HttpPost]
        //      public IActionResult WithdrawAmount()
        //      {
        //          return RedirectToAction("Feedback","Vr");
        //}

        [HttpPost]
        public async Task<IActionResult> WithdrawAmount(int amount)
        {
            try
            {
                // Here, you might implement the logic to handle the withdrawal of the specified amount.
                // For demonstration purposes, this is just a placeholder.

                // Your withdrawal logic goes here...

                // For demonstration, I'll simulate a delay using Task.Delay.
                await Task.Delay(2000); // Simulating a 2-second delay.

                // After the withdrawal process (simulated delay), you might set a success message.
                TempData["WSuccessMsg"] = $"Successfully withdrew ${amount}";

                // Redirect back to the withdrawal page or another appropriate action/view
                return RedirectToAction("Feedback", "Vr"); // Redirect to the Home/Index page after withdrawal.
            }
            catch (Exception ex)
            {
                // In case of an error during withdrawal, set an error message.
                TempData["WErrorMsg"] = $"Error occurred while withdrawing ${amount}: {ex.Message}";

                // Redirect back to the withdrawal page or another appropriate action/view
                return RedirectToAction("Index", "Home"); // Redirect to the Home/Index page after an error.
            }
        }
        public IActionResult WithdrawAmountOA(decimal Amount)
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

    }
}