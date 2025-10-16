

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;

public class StudentController(ApplicationDbContext context) : Controller
{
   private readonly ApplicationDbContext _context = context;

   public IActionResult Index()
   {
      var students = _context.Students.ToList();
      return View(students);
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

      return Json(new
      {
         success = true,
         Name = name,
         Email = email,
         Age = age
      });
   }

   [HttpGet]
   public IActionResult Edit(int id)
   {
      Student student = _context.Find<Student>(id);
      if (student == null)
      {
        return NotFound();
      }
      return View(student);

   }
}