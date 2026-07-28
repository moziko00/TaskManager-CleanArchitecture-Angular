using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.Persistence;

namespace TaskManager.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagerDbContext _context;

        public UnitOfWork(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
