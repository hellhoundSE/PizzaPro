using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class Type
    {
        public Type()
        {
            Additional = new HashSet<Additional>();
            Meal = new HashSet<Meal>();
        }

        public int IdType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Additional> Additional { get; set; }
        public virtual ICollection<Meal> Meal { get; set; }
    }
}
