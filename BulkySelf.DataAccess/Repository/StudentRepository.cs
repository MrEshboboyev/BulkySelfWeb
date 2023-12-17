using BulkySelf.DataAccess.Data;
using BulkySelf.DataAccess.Repository.IRepository;
using BulkySelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkySelf.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Student obj)
        {
            _db.Students.Update(obj);
        }
    }
}
