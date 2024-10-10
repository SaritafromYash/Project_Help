using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHub_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly IEnquiryService _enquiryService;

        public EnquiryController(IEnquiryService enquiryService)
        {
            _enquiryService = enquiryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enquiry>>> GetAllEnquiries()
        {
            var enquiries = await _enquiryService.GetAllEnquiriesAsync();
            return Ok(enquiries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enquiry>> GetEnquiryById(int id)
        {
            var enquiry = await _enquiryService.GetEnquiryByIdAsync(id);
            if (enquiry == null)
            {
                return NotFound();
            }
            return enquiry;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Enquiry>> AddEnquiry(Enquiry enquiry)
        {
            await _enquiryService.AddEnquiryAsync(enquiry);
            return CreatedAtAction(nameof(GetEnquiryById), new { id = enquiry.EnquiryId }, enquiry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnquiry(int id, Enquiry enquiry)
        {
            try
            {
                await _enquiryService.UpdateEnquiryAsync(id, enquiry);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnquiry(int id)
        {
            try
            {
                await _enquiryService.DeleteEnquiryAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
