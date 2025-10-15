

using Microsoft.AspNetCore.Mvc;

public class StudentController:Controller
{
   public IActionResult Index()
   {
      return View();
   }
}