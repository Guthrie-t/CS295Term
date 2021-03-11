using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS295_Term.Models;
using Microsoft.EntityFrameworkCore;
using CS295_Term.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CS295_Term.Controllers
{
    public class RecipeController : Controller
    {
        IRecipeRepository repo;
        UserManager<SiteUser> userManager;
        private RecipeContext context { get; set; }

        public RecipeController(IRecipeRepository r, RecipeContext ctx, UserManager<SiteUser> u)
        {
            repo = r;
            context = ctx;
            userManager = u;
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

        [Authorize]
        public IActionResult AddRecipe()
        {
            ViewBag.Action = "Add";
            return View("EditRecipe", new Recipe());
        }
        [Authorize]
        public IActionResult EditRecipe(int id)
        {
            Recipe recipe = repo.Recipes.Where(r => r.RecipeId == id).ToList()[0];
            return View(recipe);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditRecipe(Recipe recipe)
        {
            
            if (ModelState.IsValid)
            {
                if (recipe.RecipeId == 0)
                {
                    repo.AddRecipe(recipe);
                }
                else
                {
                    recipe.OverallRating = recipe.UserRating;
                    recipe.LastUpdated = DateTime.Now;
                    repo.UpdateRecipe(recipe);
                }
                return RedirectToAction("Index", "Recipe");
            }
            else
                ViewBag.Action = (recipe.RecipeId == 0) ? "Add" : "Edit";
                return View(recipe);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete (int id)
        {
            Recipe recipe = repo.Recipes.Where(r => r.RecipeId ==id).ToList()[0];
            return View(recipe);
        }

        [Authorize(Roles = "Admin")]
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
