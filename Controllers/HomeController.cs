using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dojo_survey_validation.Models;

namespace dojo_survey_validation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View("Index");
    }
    [HttpPost]
    [Route("results")]
    public IActionResult Submission(DojoSurvey survey)
    {
        if (ModelState.IsValid)
        {
            return View("Results", survey);
        }
        else
        {
            return View("Index", survey);
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}