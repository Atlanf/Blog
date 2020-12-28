using Blog.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    interface IDrawingRepository
    {
        Task<Drawing> AddDrawingAsync(Drawing newDrawing);
        Task<Drawing> UpdateDrawingAsync(Drawing drawingToUpdate);
        Task<Drawing> DeleteDrawingAsync(Drawing drawingToDelete, bool softDelete);
    }
}
