using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        // Default action for Welcome Page
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to Student Management System!";
            return View("Welcome"); 
        }
    }
}