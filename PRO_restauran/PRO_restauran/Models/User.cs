using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class User
    {
        public User()
        {
            Delivery = new HashSet<Delivery>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
