using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBookAsync(Book newBook)
        {
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return await _context.Books.FindAsync(newBook);
        }

        public async Task<Book> UpdateBookAsync(Book bookToUpdate)
        {
            _context.Entry(bookToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.Books.FindAsync(bookToUpdate);
        }

        public async Task<Book> DeleteBookAsync(Book bookToDelete, bool softDelete)
        {
            if (softDelete)
            {
                bookToDelete.IsDeleted = true;
                _context.Entry(bookToDelete).State = EntityState.Modified;
            }
            else
            {
                _context.Books.Remove(bookToDelete);
            }
            await _context.SaveChangesAsync();

            return await _context.Books.FindAsync(bookToDelete);
        }
    }
}
