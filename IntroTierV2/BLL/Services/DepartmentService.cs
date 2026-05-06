using AutoMapper;
using BLL.DTOs;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DepartmentService
    {
        DepartmentRepo repo;
        Mapper mapper;
        public DepartmentService(DepartmentRepo repo) { 
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<DepartmentDTO> Get() { 
            //retrieve all the departments
            var data = repo.Get();
            //convert this EF Model into DTO
            var res = mapper.Map<List<DepartmentDTO>>(data);
            return res;
        }

        public DepartmentDTO Get(int id) { 
            var data = repo.Get(id);
            //convert to DTO
            var res = mapper.Map<DepartmentDTO>(data);
            return res;
        }


    }
}
