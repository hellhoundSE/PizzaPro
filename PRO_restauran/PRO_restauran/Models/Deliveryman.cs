using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class Deliveryman
    {
        public Deliveryman()
        {
            Delivery = new HashSet<Delivery>();
        }

        public int IdDeliveryman { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public string HomeAddress { get; set; }
        public DateTime EmploymentDate { get; set; }

        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
