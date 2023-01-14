using System;
using System.Collections.Generic;

namespace web_crud.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }

        public int Idhotel { get; set; }
        public string? Location { get; set; }
        public string? Amenities { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
