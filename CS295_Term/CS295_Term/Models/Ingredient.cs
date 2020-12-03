using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_Term.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string Amount { get; set; }
        public int RecipeID { get; set; }

    }
}
