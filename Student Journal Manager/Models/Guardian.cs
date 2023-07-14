using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Journal_Manager.Models
{
    public class Guardian
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public int InvoiceDataId { get; set; }
        public ICollection<Student> Students { get; set; }
        public InvoiceData InvoiceData { get; set; }
    }
}
