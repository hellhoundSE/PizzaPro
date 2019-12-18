using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Delivery = new HashSet<Delivery>();
        }

        public int IdRestaurant { get; set; }
        public string Address { get; set; }
        public int Size { get; set; }

        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
