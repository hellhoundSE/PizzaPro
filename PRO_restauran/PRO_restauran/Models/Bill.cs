using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class Bill
    {
        public Bill()
        {
            Delivery = new HashSet<Delivery>();
        }

        public int IdBill { get; set; }
        public int TotalCost { get; set; }
        public int Time { get; set; }
        public string PaymentMethod { get; set; }
        public int OrderIdOrder { get; set; }

        public virtual Order OrderIdOrderNavigation { get; set; }
        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
