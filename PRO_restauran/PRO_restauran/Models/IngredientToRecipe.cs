using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class IngredientToRecipe
    {
        public int IngredientIdIngredient { get; set; }
        public int Amount { get; set; }
        public int MealIdMeal { get; set; }

        public virtual Ingredient IngredientIdIngredientNavigation { get; set; }
        public virtual Meal MealIdMealNavigation { get; set; }
    }
}
