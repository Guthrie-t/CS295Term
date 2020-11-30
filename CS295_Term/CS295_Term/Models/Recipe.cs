using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CS295_Term.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string PrivacyToggle { get; set; }
        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
        public int UserRating { get; set; }
        public string Category { get; set; }
    }
}
