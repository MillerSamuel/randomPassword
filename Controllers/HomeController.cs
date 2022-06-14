using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using randomPassword.Models;
using Microsoft.AspNetCore.Http;



namespace randomPassword.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        if(HttpContext.Session.GetInt32("counter")==null){
            HttpContext.Session.SetInt32("counter",1);
        }
        else{
            int count= (int) HttpContext.Session.GetInt32("counter")+1;
            HttpContext.Session.SetInt32("counter",count);
        }
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
