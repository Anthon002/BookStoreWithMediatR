using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Commands;
using BookStore.Application.RepositoryInfrastructure;
using MediatR;

namespace BookStore.Application.Handlers
{
    public class DeleteBookCommandHandler:IRequestHandler<DeleteBookCommand,bool>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(DeleteBookCommand reqeust, CancellationToken token)
        {
            bool response = await _bookRepository.DeleteBook(reqeust.Title);
            return response;
        }
    }
}