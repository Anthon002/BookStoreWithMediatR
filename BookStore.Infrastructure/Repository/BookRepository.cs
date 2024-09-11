using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.RepositoryInfrastructure;
using BookStore.Domain.ViewModels;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BookViewModel>> GetAllBooks()
        {
            List<BookViewModel> books = await _dbContext.BookTable.Select(x => new BookViewModel{Title = x.Title, Author = x.Author, DatePublished = x.DatePublished, Synopsis = x.Synopsis}).ToListAsync();
            return books;
        }
    }
}