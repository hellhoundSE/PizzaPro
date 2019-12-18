using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class Order
    {
        public Order()
        {
            Bill = new HashSet<Bill>();
            MealToOrder = new HashSet<MealToOrder>();
        }

        public int IdOrder { get; set; }
        public int Cost { get; set; }

        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<MealToOrder> MealToOrder { get; set; }
    }
}
