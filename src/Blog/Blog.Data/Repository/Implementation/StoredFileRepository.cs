using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Implementation
{
    public class StoredFileRepository : IStoredFileRepository
    {
        private readonly AppDbContext _context;

        public StoredFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StoredFile> AddFileAsync(StoredFile newFile)
        {
            await _context.StoredFiles.AddAsync(newFile);
            await _context.SaveChangesAsync();

            return await _context.StoredFiles.FindAsync(newFile);
        }

        public async Task<StoredFile> UpdateFileAsync(StoredFile fileToUpdate)
        {
            _context.Entry(fileToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.StoredFiles.FindAsync(fileToUpdate);
        }

        public async Task<StoredFile> DeleteFileAsync(StoredFile fileToDelete, bool softDelete)
        {
            if (softDelete)
            {
                fileToDelete.IsDeleted = true;
                _context.Entry(fileToDelete).State = EntityState.Modified;
            }
            else
            {
                _context.StoredFiles.Remove(fileToDelete);
            }
            await _context.SaveChangesAsync();

            return await _context.StoredFiles.FindAsync(fileToDelete);
        }

        public async Task<StoredFile> GetFileByUniqueNameAsync(string name)
        {
            return await _context.StoredFiles
                .Where(file => file.FileUniqueName == name)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<StoredFile>> GetFilesByUniqueNameAsync(IList<string> names)
        {
            if (names.Count > 0)
            {
                return await _context.StoredFiles
                    .Where(file => names.Any(uniqueName => uniqueName == file.FileUniqueName))
                    .ToListAsync();
            }
            else
            {
                return new List<StoredFile>();
            }
        }
    }
}
