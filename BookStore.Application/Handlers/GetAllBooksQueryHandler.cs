using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Queries;
using BookStore.Application.RepositoryInfrastructure;
using BookStore.Domain.ViewModels;
using MediatR;

namespace BookStore.Application.Handlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            List<BookViewModel> books = await _bookRepository.GetAllBooks();
            return books;
        }
    }
}