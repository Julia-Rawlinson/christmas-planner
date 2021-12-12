using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSecurity.Models
{
    
    public interface IGiftRepository
    {
        IQueryable<Gift> Gifts { get; }

        IQueryable<Gift> UserGifts(AppUser user);
        IQueryable<Gift> UserShoppingList(AppUser user);

        void AddGift(Gift gift);

        void DeleteGift(Gift gift);
    }
}
