using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class DepartmentRepo
    {
        UMSContext db;
        public DepartmentRepo(UMSContext db )
        {
            this.db = db;
        }
        public Department Get(int id) {
            return db.Departments.Find(id);
        }
        public bool Create(Department s) { 
            db.Departments.Add(s);
            return db.SaveChanges() > 0;
        }
        public bool Update(Department d) {
            var exobj = Get(d.Id);
            db.Entry(exobj).CurrentValues.SetValues(d);
            return db.SaveChanges()>0;
        }
        public bool Delete(int id) {
            var exobj = Get(id);
            db.Departments.Remove(exobj);   
            return db.SaveChanges() > 0;    
        }
        public List<Department> GetAll() {
            return db.Departments.ToList();
            /*var list = new List<Department>();
            for (int i = 1; i <= 10; i++) { 
                list.Add(new Department() { 
                    Id = i,
                    Name = "D"+i
                });
            }
            return list;*/
        }
    }
}
