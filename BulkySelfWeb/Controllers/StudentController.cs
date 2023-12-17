using BulkySelf.DataAccess.Data;
using BulkySelf.DataAccess.Repository.IRepository;
using BulkySelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkySelfWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Student> Students = _unitOfWork.Student.GetAll().ToList();
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
                _unitOfWork.Student.Add(student);
                _unitOfWork.Save();
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
            Student student = _unitOfWork.Student.Get(u => u.Id == id);
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
                _unitOfWork.Student.Update(student);
                _unitOfWork.Save();
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
            Student student = _unitOfWork.Student.Get(u => u.Id == id);
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
            Student student = _unitOfWork.Student.Get(u => u.Id == id);
            if(student == null)
            {
                return NotFound();
            }

            _unitOfWork.Student.Remove(student);
            _unitOfWork.Save();
            TempData["success"] = "Student deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
