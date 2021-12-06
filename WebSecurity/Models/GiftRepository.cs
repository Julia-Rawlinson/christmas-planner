using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSecurity.Models
{
    public class GiftRepository : IGiftRepository
    {
        private ApplicationDbContext _context;

        public GiftRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Gift> Gifts => _context.Gifts;

        //Returns the user's list if WISH gifts, not the shopping list.
        public IQueryable<Gift> UserGifts(AppUser user)
        {
            return _context.Gifts.Where(u => u.UserID == user.Id);
        }

        public void AddGift(Gift gift)
        {
            _context.Gifts.Add(gift);
            _context.SaveChanges();
        }

        public void DeleteGift(Gift gift)
        {
            _context.Gifts.Remove(gift);
            _context.SaveChanges();
        }
    }
}
