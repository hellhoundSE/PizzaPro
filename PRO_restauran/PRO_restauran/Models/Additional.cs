using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class Additional
    {
        public Additional()
        {
            AdditionalToMeal = new HashSet<AdditionalToMeal>();
        }

        public int IdAdditional { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int TypeIdType { get; set; }

        public virtual Type TypeIdTypeNavigation { get; set; }
        public virtual ICollection<AdditionalToMeal> AdditionalToMeal { get; set; }
    }
}
