using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Journal_Manager.Models
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LessonName { get; set; }
        public decimal Price { get; set; }
        public ICollection<LessonStudent> LessonStudents { get; set; }
    }
}
