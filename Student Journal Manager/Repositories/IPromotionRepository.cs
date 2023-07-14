using Student_Journal_Manager.Models;
using System.Collections.Generic;

namespace Student_Journal_Manager.Repositories
{
    public interface IPromotionRepository
    {
        void CreatePromotion(Promotion promotion);
        Promotion GetPromotionById(int id);
        List<Promotion> GetAllPromotions();
        void UpdatePromotion(Promotion promotion);
        void DeletePromotion(int id);
    }
}
