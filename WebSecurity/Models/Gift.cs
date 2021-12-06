using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSecurity.Models
{
    public class Gift
    {
        public int GiftId { get; set; }

        [Required(ErrorMessage ="Title is Required")]
        public string Title { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [Required(ErrorMessage = "Price is Required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        public bool IsWish { get; set; }
        public string UserID { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
