using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.DAL;
using OpenAI_API;
using OpenAI_API.Completions;

namespace WebApplication1.Controllers
{
    public class VoiceAssistanceController : Controller
    {
       
       
        public IActionResult Index()
        {
            return View();
        }

    }

}