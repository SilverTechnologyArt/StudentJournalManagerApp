namespace Student_Journal_Manager.Models
{
    public class LessonStudent
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
