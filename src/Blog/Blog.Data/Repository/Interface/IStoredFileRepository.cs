using Blog.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    interface IStoredFileRepository
    {
        Task<StoredFile> AddFileAsync(StoredFile newFile);
        Task<StoredFile> UpdateFileAsync(StoredFile fileToUpdate);
        Task<StoredFile> DeleteFileAsync(StoredFile fileToDelete, bool softDelete);
    }
}
