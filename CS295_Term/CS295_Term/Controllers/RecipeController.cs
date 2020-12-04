using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS295_Term.Models;
using Microsoft.EntityFrameworkCore;

namespace CS295_Term.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeContext context { get; set; }

        public RecipeController(RecipeContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var recipes = context.Recipe.OrderBy(r => r.RecipeName).ToList();
            return View(recipes);
        }

        public IActionResult SingleRecipe()
        {
            return View();
        }

        public IActionResult EditRecipe()
        {
            return View();
        }
    }
}
