using System;
using System.Collections.Generic;

namespace web_crud.Models
{
    public partial class Review
    {
        public int Iduser { get; set; }
        public int Idroom { get; set; }
        public decimal? Rating { get; set; }
        public string? Text { get; set; }

        public virtual Room IdroomNavigation { get; set; } = null!;
        public virtual User IduserNavigation { get; set; } = null!;
    }
}
