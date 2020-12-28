using Blog.Data.Model;
using Blog.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Implementation
{
    public class DrawingRepository : IDrawingRepository
    {
        private readonly AppDbContext _context;

        public DrawingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Drawing> AddDrawingAsync(Drawing newDrawing)
        {
            await _context.Drawings.AddAsync(newDrawing);
            await _context.SaveChangesAsync();

            return await _context.Drawings.FindAsync(newDrawing);
        }

        public async Task<Drawing> UpdateDrawingAsync(Drawing drawingToUpdate)
        {
            _context.Entry(drawingToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.Drawings.FindAsync(drawingToUpdate);
        }

        public async Task<Drawing> DeleteDrawingAsync(Drawing drawingToDelete, bool softDelete)
        {
            if (softDelete)
            {
                drawingToDelete.IsDeleted = true;
                _context.Entry(drawingToDelete).State = EntityState.Modified;
            }
            else
            {
                _context.Drawings.Remove(drawingToDelete);
            }
            await _context.SaveChangesAsync();

            return await _context.Drawings.FindAsync(drawingToDelete);
        }
    }
}
