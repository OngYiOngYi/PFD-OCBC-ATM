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

        [HttpPost]
        public IActionResult WithdrawAmount()
        {
            return RedirectToAction("Feedback","Vr");
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