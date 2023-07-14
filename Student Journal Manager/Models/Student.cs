namespace Student_Journal_Manager.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int GuardianId { get; set; }
        public Attendance Attendance { get; set; } = new Attendance();
    }
}
