using Student_Journal_Manager.Models;
using Student_Journal_Manager.Repositories;
using System.Collections.Generic;

namespace Student_Journal_Manager.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public void CreatePromotion(Promotion promotion)
        {
            _promotionRepository.CreatePromotion(promotion);
        }

        public Promotion GetPromotionById(int id)
        {
            return _promotionRepository.GetPromotionById(id);
        }

        public List<Promotion> GetAllPromotions()
        {
            return _promotionRepository.GetAllPromotions();
        }

        public void UpdatePromotion(Promotion promotion)
        {
            _promotionRepository.UpdatePromotion(promotion);
        }

        public void DeletePromotion(int id)
        {
            _promotionRepository.DeletePromotion(id);
        }
    }
}
