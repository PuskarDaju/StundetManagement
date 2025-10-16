using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;

namespace StudentManagement.Web.Controllers.Student
{
    [ApiController]
    [Route("student-api")]
    public class StudentApiController(ApplicationDbContext context):Controller
    {
        private readonly ApplicationDbContext _context = context;

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] Models.Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(new { message = "Student added successfully", studentId = student.student_id });
        }

        [HttpPost("edit/{id:int}")]
        public IActionResult Edit(int id,[FromBody] Models.Student student)
        {
            Models.Student st = _context.Find<Models.Student>(id);
            if (st == null)
            {
                return NotFound();
            }

// Update only the fields that the user can change
            st.name = student.name;
            st.age = student.age;
            st.email = student.email;

            _context.SaveChanges(); // persist changes

            return Ok(new
            {
                Status = "success",
                message = "Student updated successfully"
            });
        }
    }
}