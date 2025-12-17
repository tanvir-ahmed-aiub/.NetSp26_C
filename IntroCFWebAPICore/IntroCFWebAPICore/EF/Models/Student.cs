using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCFWebAPICore.EF.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName ="VARCHAR")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
        [ForeignKey("Dept")]
        public int DeptId { get; set; }
        public virtual Department Dept { get; set; }
    }
}
