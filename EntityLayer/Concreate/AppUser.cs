using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class AppUser : IdentityUser<Guid>, IEntity // burası daha sonra IEntity olrak tanımlanmıştır bilgine hata oluşturursa silersin. Admin-UserController için oluşturuldu. çalıştı şimdilik hata vermedi ileriki kısmında problem çıkarmazsa hep kalsın çıkartırsa silersin
    {
        public string? ImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Gender { get; set; }

        public List<Reservation> Reservations { get; set;}
        public List<Comment> Comments { get; set; }


    }
}
