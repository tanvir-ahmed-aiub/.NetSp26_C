using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCFWebAPICore.EF.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName ="VARCHAR")]
        public string Name { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }

    }
}
