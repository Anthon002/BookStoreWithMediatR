using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.ViewModels;
using MediatR;

namespace BookStore.Application.Queries
{
    public record GetAllBooksQuery(): IRequest<List<BookViewModel>>;
}