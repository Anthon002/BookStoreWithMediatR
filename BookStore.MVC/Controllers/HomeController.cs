using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.MVC.Models;
using BookStore.Domain.ViewModels;
using MediatR;
using BookStore.Application.Queries;

namespace BookStore.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    public HomeController(ILogger<HomeController> logger, IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookViewModel>>> Index()
    {
        List<BookViewModel> books = await _mediator.Send(new GetAllBooksQuery());
        return View(books);
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
