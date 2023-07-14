using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Repositories;

namespace Student_Journal_Manager.Services
{
    public class InvoiceDataService : IInvoiceDataService
    {
        private readonly IInvoiceDataRepository _invoiceDataRepository;

        public InvoiceDataService(IInvoiceDataRepository invoiceDataRepository)
        {
            _invoiceDataRepository = invoiceDataRepository;
        }

        public async Task<List<InvoiceData>> GetAllInvoiceData()
        {
            return await _invoiceDataRepository.GetAllInvoiceData();
        }

        public async Task<InvoiceData> GetInvoiceDataById(int id)
        {
            return await _invoiceDataRepository.GetInvoiceDataById(id);
        }

        public async Task AddInvoiceData(InvoiceData invoiceData)
        {
            await _invoiceDataRepository.AddInvoiceData(invoiceData);
        }

        public async Task UpdateInvoiceData(InvoiceData invoiceData)
        {
            await _invoiceDataRepository.UpdateInvoiceData(invoiceData);
        }

        public async Task DeleteInvoiceData(int id)
        {
            await _invoiceDataRepository.DeleteInvoiceData(id);
        }
    }
}