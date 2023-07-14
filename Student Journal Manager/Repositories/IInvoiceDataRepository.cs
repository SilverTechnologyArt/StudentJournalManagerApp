using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public interface IInvoiceDataRepository
    {
        Task<List<InvoiceData>> GetAllInvoiceData();
        Task<InvoiceData> GetInvoiceDataById(int id);
        Task AddInvoiceData(InvoiceData invoiceData);
        Task UpdateInvoiceData(InvoiceData invoiceData);
        Task DeleteInvoiceData(int id);
    }
}
