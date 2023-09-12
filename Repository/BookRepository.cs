using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal_API.Data;
using Minimal_API.Models;
using Minimal_API.Models.DTOs;

namespace Minimal_API.Repository
{
    public class BookRepository : IBookRepository<Book>
    {
        private AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Book> Add(Book newBook)
        {
            var result = await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Book> Delete(Book bookToDelete)
        {
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return bookToDelete;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.ID == id);

		}

        public async Task<Book> Update(Book book)
        {
            var result = await _context.Books.FindAsync(book.ID);
            if (result != null)
            {
                result.Name = book.Name;
                result.Author = book.Author;
                result.Description = book.Description;
                result.ReleaseYear = book.ReleaseYear;
                _context.Books.Update(result);
                _context.SaveChanges();
            }
            return book;
        }
    }
}
