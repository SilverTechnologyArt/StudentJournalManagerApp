using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Services
{
    public interface IInvoiceDataService
    {
        Task<List<InvoiceData>> GetAllInvoiceData();
        Task<InvoiceData> GetInvoiceDataById(int id);
        Task AddInvoiceData(InvoiceData invoiceData);
        Task UpdateInvoiceData(InvoiceData invoiceData);
        Task DeleteInvoiceData(int id);
    }
}