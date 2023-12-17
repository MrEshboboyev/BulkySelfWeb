using BulkySelf.DataAccess.Data;
using BulkySelf.DataAccess.Repository.IRepository;
using BulkySelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkySelfWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public IActionResult Index()
        {
            List<Student> Students = _studentRepo.GetAll().ToList();
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
                _studentRepo.Add(student);
                _studentRepo.Save();
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
            Student student = _studentRepo.Get(u => u.Id == id);
            if (student == null)
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
                _studentRepo.Add(student);
                _studentRepo.Save();
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
            Student student = _studentRepo.Get(u => u.Id == id);
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
            Student student = _studentRepo.Get(u => u.Id == id);
            if(student == null)
            {
                return NotFound();
            }

            _studentRepo.Add(student);
            _studentRepo.Save();
            TempData["success"] = "Student deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
