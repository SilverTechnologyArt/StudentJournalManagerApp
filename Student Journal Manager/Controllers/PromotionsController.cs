using Microsoft.AspNetCore.Mvc;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Services;
using System;

namespace Student_Journal_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet]
        public IActionResult GetAllPromotions()
        {
            var promotions = _promotionService.GetAllPromotions();
            return Ok(promotions);
        }

        [HttpGet("{id}")]
        public IActionResult GetPromotionById(int id)
        {
            var promotion = _promotionService.GetPromotionById(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }

        [HttpPost]
        public IActionResult CreatePromotion(Promotion promotion)
        {
            try
            {
                _promotionService.CreatePromotion(promotion);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePromotion(int id, Promotion promotion)
        {
            try
            {
                var existingPromotion = _promotionService.GetPromotionById(id);
                if (existingPromotion == null)
                {
                    return NotFound();
                }

                _promotionService.UpdatePromotion(promotion);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePromotion(int id)
        {
            try
            {
                var existingPromotion = _promotionService.GetPromotionById(id);
                if (existingPromotion == null)
                {
                    return NotFound();
                }

                _promotionService.DeletePromotion(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
