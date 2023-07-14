using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Services;
using Student_Journal_Manager.Context;

namespace Student_Journal_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianService _guardianService;
        private readonly MyDbContext _context;

        public GuardianController(IGuardianService guardianService)
        {
            _guardianService = guardianService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuardians()
        {
            var guardians = await _guardianService.GetAllGuardians();
            return Ok(guardians);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuardianById(int id)
        {
            var guardian = await _guardianService.GetGuardianById(id);
            if (guardian == null)
                return NotFound();

            return Ok(guardian);
        }

        [HttpPost]
        public async Task<IActionResult> AddGuardian([FromBody] GuardianDto guardianDto)
        {

            var guardian = new Guardian
            {
                FirstName = guardianDto.FirstName,
                LastName = guardianDto.LastName,
                //InvoiceDataId = guardianDto.InvoiceDataId,
                Students = guardianDto.Students.Select(s => new Student
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList()
            };

            var invoiceData = new InvoiceData
            {
                InvoiceNumber = guardianDto.InvoiceDataDto.InvoiceNumber,
                DateOfInvoice = guardianDto.InvoiceDataDto.DateOfInvoice,
                DateOfRelease = guardianDto.InvoiceDataDto.DateOfRelease,
                DateOfPayment = guardianDto.InvoiceDataDto.DateOfPayment,
                FormOfPayment = guardianDto.InvoiceDataDto.FormOfPayment,
                AccountNumber = guardianDto.InvoiceDataDto.AccountNumber,
                IsPaymentDivided = guardianDto.InvoiceDataDto.IsPaymentDivided,
                IsPaid = guardianDto.InvoiceDataDto.IsPaid,
                BuyerName = guardianDto.InvoiceDataDto.BuyerName,
                Remarks = guardianDto.InvoiceDataDto.Remarks,
                PostCity = guardianDto.InvoiceDataDto.PostCity,
                Street = guardianDto.InvoiceDataDto.Street,
                Country = guardianDto.InvoiceDataDto.Country,
                PostCode = guardianDto.InvoiceDataDto.PostCode,
                BuildingNumber = guardianDto.InvoiceDataDto.BuildingNumber,
                FlatNumber = guardianDto.InvoiceDataDto.FlatNumber,
                Nip = guardianDto.InvoiceDataDto.Nip,

            };

            guardian.InvoiceData = invoiceData;

            guardian.Id = 0;
            await _guardianService.AddGuardian(guardian);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuardian(int id, [FromBody] Guardian guardian)
        {
            if (id != guardian.Id)
                return BadRequest();

            try
            {
                await _guardianService.UpdateGuardian(guardian);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuardian(int id)
        {
            await _guardianService.DeleteGuardian(id);
            return Ok();
        }
    }
}