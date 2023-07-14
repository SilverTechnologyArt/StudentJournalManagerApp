using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Journal_Manager.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public int[] Hours { get; set; }

        public string SerializedHours
        {
            get => string.Join(",", Hours);
            set => Hours = value.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
