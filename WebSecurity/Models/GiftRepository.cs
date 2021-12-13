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
        public IQueryable<Gift> Gifts => _context.Gift;

        public IQueryable<Gift> ShoppingList => throw new NotImplementedException();

        //Returns the user's list if WISH gifts, not the shopping list.
        public IQueryable<Gift> UserGifts(AppUser user)
        {
            return _context.Gift.Where(u => u.UserID == user.Id && u.IsWish);
        }
        public IQueryable<Gift> UserShoppingList(AppUser user)
        {
            return _context.Gift.Where(u => u.UserID == user.Id && !u.IsWish);
        }

        public void AddGift(Gift gift)
        {
            _context.Gift.Add(gift);
            _context.SaveChanges();
        }

        public void DeleteGift(Gift gift)
        {
            _context.Gift.Remove(gift);
            _context.SaveChanges();
        }

    }
}
