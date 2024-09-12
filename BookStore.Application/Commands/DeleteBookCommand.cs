using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BookStore.Application.Commands
{
    public record DeleteBookCommand(string Title): IRequest<bool>;
}