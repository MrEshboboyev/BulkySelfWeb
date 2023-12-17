using BulkySelf.DataAccess.Data;
using BulkySelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkySelfWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Student> Students = _db.Students.ToList();
            return View(Students);
        }

        // create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                TempData["success"] = "Student created successfully!";
                return RedirectToAction("Index");
            }

            return View();
        }


        // Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Student student = _db.Students.Find(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                _db.Students.Update(student);
                _db.SaveChanges();
                TempData["success"] = "Student updated successfully!";
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Student student = _db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Student student = _db.Students.Find(id);
            if(student == null)
            {
                return NotFound();
            }

            _db.Students.Remove(student);
            _db.SaveChanges();
            TempData["success"] = "Student deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
