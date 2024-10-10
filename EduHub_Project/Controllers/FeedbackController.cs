using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHub_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAllFeedback()
        {
            var feedback = await _feedbackService.GetAllFeedback();
            return Ok(feedback);
        }

        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost]
      
        public async Task<IActionResult> AddFeedback([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _feedbackService.AddFeedback(feedback);
            return CreatedAtAction("GetFeedbackById", new { id = feedback.FeedBackId }, feedback);
        }

        
       
    }
}
