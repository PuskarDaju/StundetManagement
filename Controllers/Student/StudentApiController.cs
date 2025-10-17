using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;

namespace StudentManagement.Web.Controllers.Student
{
    [ApiController]
    [Route("student-api")]
    public class StudentApiController(ApplicationDbContext context):ControllerBase
    {
       
        private readonly ApplicationDbContext _context = context;

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert(Models.Student student)
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

            st.name = student.name;
            st.email = student.email;
            st.age = student.age;
            
           _context.Update(st);
           if (_context.SaveChanges() > 0)
           {
               return Ok(st);
           }

            return BadRequest(new
            {
                Status = "Error",
                message = "Student cannot be updated"
            });
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            Models.Student st = _context.Students.Find(id);
            if (st == null)
            {
                return NotFound();
            }
            
            _context.Remove(st);
            _context.SaveChanges();
            return Ok(new
            {
                Status = "success",
                message = "Student deleted successfully"
            }); 
        }
        
    }
}