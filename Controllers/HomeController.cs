using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using moment2dotnet.Models;
using Newtonsoft.Json;

namespace moment2dotnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var jsonStr = System.IO.File.ReadAllText("treats.json"); 
        var jsonObj = JsonConvert.DeserializeObject<IEnumerable<Treats>>(jsonStr); 
        return View(jsonObj);
    }

    public IActionResult Info()
    {
        ViewData["Info"] = "Här kommer lite info från Controllern"; 
        return View();
    } 

    [Route("/om")]
    public IActionResult About()
    {
        ViewBag.Message= "Hej, här är ett meddelande från Controllern";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
