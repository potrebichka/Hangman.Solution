using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Hangman.Models;

namespace Hangman.Controllers
{
    public class GameController : Controller
    {
        [HttpGet("/hangman")]
        public ActionResult Index()
        {
            return View();
        }
    }
}