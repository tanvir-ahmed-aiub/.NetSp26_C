using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DepartmentService
    {
        DepartmentRepo repo;
        public DepartmentService(DepartmentRepo repo)
        {
            this.repo = repo;
        }
        public List<DepartmentDTO> All() {
            var data = repo.GetAll();
            var ret = MapperConfig.GetMapper().Map<List<DepartmentDTO>>(data);
            return ret;
            
        }
        public DepartmentDTO Get(int id) { 
            Department data = repo.Get(id);
            DepartmentDTO ret = MapperConfig.GetMapper().Map<DepartmentDTO>(data);
            return ret; 
        }
        public bool Create(DepartmentDTO dto) { 
            Department data = MapperConfig.GetMapper().Map<Department>(dto);
            return repo.Create(data);
        }
    }
}
