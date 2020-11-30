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
        public int Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string FoodGroup { get; set; }

    }
}
