using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class MealToOrder
    {
        public int OrderIdOrder { get; set; }
        public int MealIdMeal { get; set; }
        public int Amount { get; set; }

        public virtual Meal MealIdMealNavigation { get; set; }
        public virtual Order OrderIdOrderNavigation { get; set; }
    }
}
