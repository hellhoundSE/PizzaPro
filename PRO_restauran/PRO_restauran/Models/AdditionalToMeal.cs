using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class AdditionalToMeal
    {
        public int MealIdMeal { get; set; }
        public int AdditionalIdAdditional { get; set; }
        public int Amount { get; set; }

        public virtual Additional AdditionalIdAdditionalNavigation { get; set; }
        public virtual Meal MealIdMealNavigation { get; set; }
    }
}
