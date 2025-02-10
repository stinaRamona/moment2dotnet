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
        HttpContext.Session.SetString("Favorite", "Dammsugare");

        var jsonStr = System.IO.File.ReadAllText("treats.json"); 
        var jsonObj = JsonConvert.DeserializeObject<IEnumerable<Treats>>(jsonStr); 
        return View(jsonObj);
    }

    public IActionResult Info()
    {
        ViewBag.Fave = HttpContext.Session.GetString("Favorite");
        ViewData["Info"] = "Här kommer lite text från Controllern"; 
        return View();
    } 

    [Route("/omfika")]
    public IActionResult About()
    {
        ViewBag.Vacuum= "Dammsugare - Ett traditionellt fikabröd med smak av arrak. Omlindade i marsipan och ändarna är doppade i choklad";
        ViewBag.Pearl="Chockladboll pärlsocker - En klassisk chokladboll baserad på smör, salt, havregryn, kaffe, socker och kakao. Rullade i pärlsocker";
        ViewBag.Coco="Chokladboll kokos - En likadan chokladboll som med pärlsocker, men istället rullad i kokos";
        ViewBag.Mazarin="Mazarin - Klassiskt fikabröd med mandelsmet, toppade med galsyr";
        ViewBag.Rasberry="Hallongrotta - En mördegskaka bakad på klassiskt vis med en klick hallonsylt i mitten";   
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
