using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quating.Models;

namespace Quating.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index(){
            //List<Dictionary<string, object>> allQuotes = DbConnector.Query("SELECT * FROM quotes");
            return View();
        }
        [HttpGet("quotes")]
        public IActionResult QuotesDisplay(){
            List<Dictionary<string, object>> allQuotes = DbConnector.Query("SELECT * FROM quotes");
            ViewBag.quotes = allQuotes;
            return View("quotes");
        }
        [HttpPost("quotes")]
        public IActionResult quotes(Quot q){
            string query =$"INSERT INTO quotes (name, quote, created_at, updated_at) VALUES ('{q.Name}', '{q.Quotes}', NOW(), NOW())";
            DbConnector.Execute(query);
            return RedirectToAction("QuotesDisplay");
        }
    }
}
