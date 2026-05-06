using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DAL.Repos
{
    public class StudentRepo
    {
        StudentMsCSp26Context db;
        public StudentRepo(StudentMsCSp26Context db) { 
            this.db = db;
        }
        public bool Create(Student s) { 
            this.db.Students.Add(s);
            return db.SaveChanges() > 0;
        }
        public Student Get(int id) {
            return db.Students.Find(id);
        }
        public List<Student> Get() { 
            return db.Students.ToList();
        }
        public bool Update(Student s) {
            var exObj = Get(s.Id);
            db.Entry(exObj).CurrentValues.SetValues(s);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id) { 
            var exobj = Get(id);
            db.Students.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}
