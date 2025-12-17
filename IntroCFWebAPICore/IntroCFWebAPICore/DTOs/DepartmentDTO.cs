using System.ComponentModel.DataAnnotations;

namespace IntroCFWebAPICore.DTOs
{
    public class DepartmentDTO
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
