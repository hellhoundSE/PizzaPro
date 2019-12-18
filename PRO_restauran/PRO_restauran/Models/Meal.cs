using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class Meal
    {
        public Meal()
        {
            AdditionalToMeal = new HashSet<AdditionalToMeal>();
            IngredientToRecipe = new HashSet<IngredientToRecipe>();
            MealToOrder = new HashSet<MealToOrder>();
        }

        public int IdMeal { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int TypeIdType { get; set; }

        public virtual Type TypeIdTypeNavigation { get; set; }
        public virtual ICollection<AdditionalToMeal> AdditionalToMeal { get; set; }
        public virtual ICollection<IngredientToRecipe> IngredientToRecipe { get; set; }
        public virtual ICollection<MealToOrder> MealToOrder { get; set; }
    }
}
