namespace Student_Journal_Manager.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public decimal Discount { get; set; }
    }
}
