using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class Delivery
    {
        public int IdDelivery { get; set; }
        public int BillIdBill { get; set; }
        public string Address { get; set; }
        public DateTime DeliveryTime { get; set; }
        public int UserIdUser { get; set; }
        public int RestaurantIdRestaurant { get; set; }
        public int DeliverymanIdDeliveryman { get; set; }

        public virtual Bill BillIdBillNavigation { get; set; }
        public virtual Deliveryman DeliverymanIdDeliverymanNavigation { get; set; }
        public virtual Restaurant RestaurantIdRestaurantNavigation { get; set; }
        public virtual User UserIdUserNavigation { get; set; }
    }
}
