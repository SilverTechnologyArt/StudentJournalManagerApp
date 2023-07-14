using System;

namespace Student_Journal_Manager.Models
{
    public class InvoiceData
    {
        public int Id { get; set; }
        public int GuardianId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public DateTime DateOfRelease { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string FormOfPayment { get; set; }
        public string AccountNumber { get; set; }
        public bool IsPaymentDivided { get; set; }
        public bool IsPaid { get; set; }
        public string BuyerName { get; set; }
        public string Remarks { get; set; }
        public string PostCity { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string Nip { get; set; }

        public Guardian Guardian { get; set; }
    }
}
