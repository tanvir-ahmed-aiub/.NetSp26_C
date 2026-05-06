using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class DepartmentRepo
    {
        StudentMsCSp26Context db;
        public DepartmentRepo(StudentMsCSp26Context db) { 
            this.db = db;
        }

        public bool Create(Department d) { 
            db.Departments.Add(d);
            return db.SaveChanges() > 0;
            //if(db.SaveChanges() >  0) return true;
            //return false;
        }
        public Department Get(int id) {
            return db.Departments.Find(id);

        }
        public List<Department> Get() { 
            return db.Departments.ToList();
        }
        public bool Update(Department d) {
            var exobj = Get(d.Id);
            db.Entry(exobj).CurrentValues.SetValues(d);
            return db.SaveChanges() > 0;


        }
        public bool Delete(int id) { 
            var exObj = Get(id); 
            db.Departments.Remove(exObj);
            return db.SaveChanges() > 0;

        }
    }
}
