using System;
using System.Collections.Generic;

namespace PRO_restauran.Models
{
    public partial class Ingredient
    {
        public int IdIngredient { get; set; }
        public string Name { get; set; }
        public bool? Vegetarian { get; set; }
        public bool? Spicy { get; set; }
        public int? Calories { get; set; }

        public virtual IngredientToRecipe IngredientToRecipe { get; set; }
    }
}
