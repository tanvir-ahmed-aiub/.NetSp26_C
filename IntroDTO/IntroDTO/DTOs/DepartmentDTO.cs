using System.ComponentModel.DataAnnotations;

namespace IntroDTO.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
    }
}
