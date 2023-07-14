namespace Student_Journal_Manager.Models
{
    public class GuardianDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public InvoiceDataDto InvoiceDataDto { get; set; }
        //public int InvoiceDataId { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}

//public string InvoiceNumber { get; set; }
//public DateTime InvoiceDate { get; set; }
//public string SellerName { get; set; }
//public string SellerAddress { get; set; }
//public string SellerTaxId { get; set; }
//public string BuyerName { get; set; }
//public string BuyerAddress { get; set; }
//public string BuyerTaxId { get; set; }
//public decimal NetAmount { get; set; }
//public decimal TaxAmount { get; set; }
//public decimal GrossAmount { get; set; }