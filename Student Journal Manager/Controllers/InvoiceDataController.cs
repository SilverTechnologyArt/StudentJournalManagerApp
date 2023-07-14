using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Services;

namespace Student_Journal_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceDataController : ControllerBase
    {
        private readonly IInvoiceDataService _invoiceDataService;

        public InvoiceDataController(IInvoiceDataService invoiceDataService)
        {
            _invoiceDataService = invoiceDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoiceData()
        {
            var invoiceData = await _invoiceDataService.GetAllInvoiceData();
            return Ok(invoiceData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceDataById(int id)
        {
            var invoiceData = await _invoiceDataService.GetInvoiceDataById(id);
            if (invoiceData == null)
                return NotFound();

            return Ok(invoiceData);
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoiceData([FromBody] InvoiceData invoiceData)
        {
            await _invoiceDataService.AddInvoiceData(invoiceData);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoiceData(int id, [FromBody] InvoiceData invoiceData)
        {
            if (id != invoiceData.Id)
                return BadRequest();

            try
            {
                await _invoiceDataService.UpdateInvoiceData(invoiceData);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceData(int id)
        {
            await _invoiceDataService.DeleteInvoiceData(id);
            return Ok();
        }
    }
}
