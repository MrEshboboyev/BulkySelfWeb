using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkySelf.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Student Name ")]
        public string Name { get; set; }

        [DisplayName("Student Course")]
        public int Course { get; set; }
    }
}
