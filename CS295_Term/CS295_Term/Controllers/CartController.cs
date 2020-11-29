using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CS295_Term.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Current = "List";
            return View();
        }
        public IActionResult CompletedList()
        {
            ViewBag.Current = "List";
            return View();
        }
    }
}
