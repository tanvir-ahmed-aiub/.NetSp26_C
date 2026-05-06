using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;

namespace BLL
{
    public class MapperConfig
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
            cfg.CreateMap<Product, ProductDTO>().ReverseMap();

        });

        public static Mapper GetMapper() {
            return new Mapper(config);
        }
    }
}
