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

        [HttpGet]
        public IActionResult SingleRecipe(int id)
        {
            var recipe = context.Recipe.Find(id);
            return View(recipe);
        }

        public IActionResult AddRecipe()
        {
            ViewBag.Action = "Add";
            return View("EditRecipe", new Recipe());
        }
        
        public IActionResult EditRecipe(int id)
        {
            var recipe = context.Recipe.Find(id);
            return View(recipe);
        }
        [HttpPost]
        public IActionResult EditRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                if (recipe.RecipeId == 0)
                {
                    recipe.DateSubmitted = DateTime.Now;
                    context.Recipe.Add(recipe);
                }
                else
                    context.Recipe.Update(recipe);
                context.SaveChanges();
                return RedirectToAction("Index", "Recipe");
            }
            else
                ViewBag.Action = (recipe.RecipeId == 0) ? "Add" : "Edit";
                return View(recipe);
        }

    }
}
