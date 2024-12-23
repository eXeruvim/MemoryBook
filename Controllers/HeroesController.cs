using MemoryBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemoryBook.Controllers;

public class HeroesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult HeroesUSSR()
    {
        var viewModel = new HeroesViewModel
        {

        };

        return View(viewModel);
    }


    public IActionResult FullCavalierOrder()
    {
        var viewModel = new HeroesViewModel
        {

        };

        return View(viewModel);
    }

    public IActionResult HeroesOfLabor()
    {
        var viewModel = new HeroesViewModel
        {

        };

        return View(viewModel);
    }

    public IActionResult FamousPeople()
    {
        var viewModel = new HeroesViewModel
        {

        };

        return View(viewModel);
    }

    public IActionResult PeoplesRepresentative()
    {
        var viewModel = new HeroesViewModel
        {

        };

        return View(viewModel);
    }


    public IActionResult VictoryParadeParticipants()
    {
        var viewModel = new HeroesViewModel
        {

        };

        return View(viewModel);
    }
}
