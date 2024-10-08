using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.MVC.Models;
using BookStore.Domain.ViewModels;
using MediatR;
using BookStore.Application.Queries;
using BookStore.Application.Commands;

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
    [HttpGet]
    public async Task<ActionResult<BookViewModel>> GetBook(string Title)
    {
        BookViewModel book = await _mediator.Send(new GetBookQuery(Title));
        return View(book);
    }
    [HttpPost]
    public async Task<ActionResult<bool>> DeleteBook(string Title)
    {
        bool response = await _mediator.Send(new DeleteBookCommand(Title));
        return RedirectToAction("Index",new {message = $"{response}"});
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
