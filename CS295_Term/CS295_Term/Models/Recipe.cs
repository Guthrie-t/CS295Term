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
        public string RecipeName { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }

        public int OverallRating { get; set; }

        public int UserRating { get; set; }

        public DateTime DateSubmitted { get; set; }

        public DateTime LastUpdated { get; set; }

        public List<Category> Categories { get; set; }
        
        public string Image { get; set; }

        public SiteUser User { get; set; }

    }

}
