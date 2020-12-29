using Blog.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book newBook);
        Task<Book> UpdateBookAsync(Book bookToUpdate);
        Task<Book> DeleteBookAsync(Book bookToDelete, bool softDelete);
    }
}
