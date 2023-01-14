using System;
using System.Collections.Generic;

namespace web_crud.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
        }

        public int Idroom { get; set; }
        public int Idhotel { get; set; }
        public string? Capacite { get; set; }
        public string? Roomtype { get; set; }
        public string? Amenities { get; set; }

        public virtual Hotel IdhotelNavigation { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
