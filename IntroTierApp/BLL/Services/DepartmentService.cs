using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DepartmentService
    {
        DepartmentRepo repo;
        public DepartmentService(DepartmentRepo repo) { 
            this.repo = repo;
        }
        public Object GetAll() {
            //logics
            //
            
            var data = repo.Get();
            //logics
            return data;

        }
        public bool Create() { //param
            
            repo.Create();
            return true;
        }
        public bool Update()
        { //param
            
            var rs= repo.Update(34);
            return true;
        }
    }
}
