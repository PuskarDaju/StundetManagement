

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;

public class StudentController(ApplicationDbContext context) : Controller
{
   private readonly ApplicationDbContext _context = context;

   public IActionResult Index()
   {
      return View();
   }

   public IActionResult Create()
   {
      return View();
   }
   [HttpPost]

   public IActionResult Insert([FromBody] JsonElement data)
   {
      // Parse values from JSON
      string name = data.GetProperty("name").GetString() ?? "";
      int age = data.GetProperty("age").GetInt32();
      string email = data.GetProperty("email").GetString() ?? "";

      // Here you can insert into DB if needed
      // _context.Students.Add(new Student { Name=name, Age=age, Email=email });
      // await _context.SaveChangesAsync();

      return Json(new
      {
         success = true,
         Name = name,
         Email = email,
         Age = age
      });
   }
}