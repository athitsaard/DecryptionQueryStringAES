using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebDecryptQueryStringAES.Models;

namespace WebDecryptQueryStringAES.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string q)
        {   
            // tset url
            // add url
            // https://localhost:44356/Home/index?q=JHr2ZKQjD4eenerUc%2fWwjnSlRSC1yjNRzHHgcB2ugYfS%2f5e5xgOIExSNNiFqTmyz5u%2bSXI9gcquXz7WsyN5Qw%2b3SmMEeI8qHk057OGcL%2bohA6T2b48N0%2fW0B83U8bPCFahSMcDdDNXVwsDD%2fHaS%2f8cZDyEwZzR0y1LaGgQVVwMoJntVkbVecurGvyKs%2bXoGCs0vLXGcmKSd8Ch2uFk3F9gMGu7bKv8EmLYePxzf63fsSpavPhF8WHeGWgJ6u46pc
            var helper = new Helper();
            var Key = "7A5E046FCA81867339A6BB651775675B23E1F770419510D8264C5C66063FE2D6";
            var IV = "39C8D541711670AD8727FE9E1AE4043C";
            if (!string.IsNullOrEmpty(q))
            {
                var queryString = helper.GetQueryString<QueryStringUrl>(q, Key, IV);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
