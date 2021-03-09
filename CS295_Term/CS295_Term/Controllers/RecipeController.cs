using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS295_Term.Models;
using Microsoft.EntityFrameworkCore;
using CS295_Term.Repositories;

namespace CS295_Term.Controllers
{
    public class RecipeController : Controller
    {
        IRecipeRepository repo;
        private RecipeContext context { get; set; }

        public RecipeController(IRecipeRepository r, RecipeContext ctx)
        {
            repo = r;
            context = ctx;
        }
        public IActionResult Index()
        {
            List<Recipe> recipes = repo.Recipes.OrderBy(r => r.RecipeName).ToList<Recipe>();
            return View(recipes);
        }
        [HttpPost]
        public IActionResult Index(string recipeName)
        {
            List<Recipe> recipes = repo.Recipes.Where(r => r.RecipeName == recipeName).ToList();

            return View(recipes);
        }

        [HttpGet]
        public IActionResult SingleRecipe(int id)
        {
            Recipe recipe = repo.Recipes.Where(r => r.RecipeId == id).ToList()[0];
            return View(recipe);
        }

        public IActionResult AddRecipe()
        {
            ViewBag.Action = "Add";
            return View("EditRecipe", new Recipe());
        }

        public IActionResult EditRecipe(int id)
        {
            Recipe recipe = repo.Recipes.Where(r => r.RecipeId == id).ToList()[0];
            return View(recipe);
        }
        [HttpPost]
        public IActionResult EditRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                if (recipe.RecipeId == 0)
                {
                    //recipe.DateSubmitted = DateTime.Now;
                    repo.AddRecipe(recipe);
                }
                else
                    repo.UpdateRecipe(recipe);
                return RedirectToAction("Index", "Recipe");
            }
            else
                ViewBag.Action = (recipe.RecipeId == 0) ? "Add" : "Edit";
                return View(recipe);
        }

        public IActionResult Delete (int id)
        {
            Recipe recipe = repo.Recipes.Where(r => r.RecipeId ==id).ToList()[0];
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Delete(Recipe recipe)
        {
            if(ModelState.IsValid)
            {
                repo.DeleteRecipe(recipe);
            }
            return RedirectToAction("Index", "Recipe");
        }
    }
}
