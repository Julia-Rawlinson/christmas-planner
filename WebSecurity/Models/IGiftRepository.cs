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

        void AddGift(Gift gift);

        void DeleteGift(Gift gift);
    }
}
