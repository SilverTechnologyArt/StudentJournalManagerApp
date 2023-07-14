using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Journal_Manager.Context;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public class InvoiceDataRepository : IInvoiceDataRepository
    {
        private readonly MyDbContext _context;

        public InvoiceDataRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<InvoiceData>> GetAllInvoiceData()
        {
            return await _context.InvoiceData.ToListAsync();
        }

        public async Task<InvoiceData> GetInvoiceDataById(int id)
        {
            return await _context.InvoiceData.FindAsync(id);
        }

        public async Task AddInvoiceData(InvoiceData invoiceData)
        {
            _context.InvoiceData.Add(invoiceData);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInvoiceData(InvoiceData invoiceData)
        {
            _context.Entry(invoiceData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceData(int id)
        {
            var invoiceData = await _context.InvoiceData.FindAsync(id);
            if (invoiceData != null)
            {
                _context.InvoiceData.Remove(invoiceData);
                await _context.SaveChangesAsync();
            }
        }
    }
}
