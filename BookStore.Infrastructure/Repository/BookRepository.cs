using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.RepositoryInfrastructure;
using BookStore.Domain.Models;
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

        public async Task<BookViewModel> GetBook(string Title)
        {
            BookViewModel book = await _dbContext.BookTable.Where(x => x.Title == Title).Select(x => new BookViewModel{Title = x.Title, Author = x.Author, DatePublished = x.DatePublished,Synopsis = x.Synopsis}).FirstAsync();
            return book;
        }
        public async Task<bool> DeleteBook(string Title)
        {
            Book book = await _dbContext.BookTable.FirstOrDefaultAsync(x => x.Title == Title);
            if (book == null)
            {
                return false;
            }
            _dbContext.BookTable.Remove(book);
            int response = await _dbContext.SaveChangesAsync();
            if (response >= 1)
            {
                return true;
            }
            return false;
        }
    }
}