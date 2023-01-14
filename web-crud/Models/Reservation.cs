using System;
using System.Collections.Generic;

namespace web_crud.Models
{
    public partial class Reservation
    {
        public int Idroom { get; set; }
        public int Iduser { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual Room IdroomNavigation { get; set; } = null!;
        public virtual User IduserNavigation { get; set; } = null!;
    }
}
