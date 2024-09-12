using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.ViewModels;

namespace BookStore.Application.RepositoryInfrastructure
{
    public interface IBookRepository
    {
        Task<List<BookViewModel>> GetAllBooks();
        Task<BookViewModel> GetBook(string Title);
        Task<bool> DeleteBook(string Title);
    }
}