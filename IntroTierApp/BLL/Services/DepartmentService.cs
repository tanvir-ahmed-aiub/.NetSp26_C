using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DepartmentService
    {
        public Object GetAll() {
            //logics
            //
            var repo = new DepartmentRepo();
            var data = repo.Get();
            //logics
            return data;

        }
        public bool Create() { //param
            var repo = new DepartmentRepo();
            repo.Create();
            return true;
        }
    }
}
