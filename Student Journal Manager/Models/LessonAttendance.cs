using System;

namespace Student_Journal_Manager.Models
{
    public class LessonAttendance
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public bool IsLocked { get; set; }
    }
}
