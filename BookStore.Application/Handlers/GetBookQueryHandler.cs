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
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookViewModel>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<BookViewModel> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            BookViewModel book = await _bookRepository.GetBook(request.Id);
            return book;
        }
    }
}