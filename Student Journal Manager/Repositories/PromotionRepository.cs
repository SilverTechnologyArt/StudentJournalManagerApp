using Student_Journal_Manager.Context;
using Student_Journal_Manager.Models;
using System.Collections.Generic;
using System.Linq;

namespace Student_Journal_Manager.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly MyDbContext _dbContext;

        public PromotionRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePromotion(Promotion promotion)
        {
            _dbContext.Promotions.Add(promotion);
            _dbContext.SaveChanges();
        }

        public Promotion GetPromotionById(int id)
        {
            return _dbContext.Promotions.FirstOrDefault(p => p.Id == id);
        }

        public List<Promotion> GetAllPromotions()
        {
            return _dbContext.Promotions.ToList();
        }

        public void UpdatePromotion(Promotion promotion)
        {
            _dbContext.Promotions.Update(promotion);
            _dbContext.SaveChanges();
        }

        public void DeletePromotion(int id)
        {
            var promotion = _dbContext.Promotions.FirstOrDefault(p => p.Id == id);
            if (promotion != null)
            {
                _dbContext.Promotions.Remove(promotion);
                _dbContext.SaveChanges();
            }
        }
    }
}
