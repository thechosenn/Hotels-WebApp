using System;
using System.Collections.Generic;

namespace web_crud.Models
{
    public partial class User
    {
        public User()
        {
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
        }

        public int Iduser { get; set; }
        public string? Fullname { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Role { get; set; }
        public string? Adresse { get; set; }
        public decimal? Phone { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
