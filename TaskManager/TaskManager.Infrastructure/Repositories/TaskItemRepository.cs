using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Infrastructure.Persistence;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly TaskManagerDbContext _context;

        public TaskItemRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems
                .Include(t => t.Project)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetByProjectIdAsync(int projectId)
        {
            return await _context.TaskItems
                .Where(t => t.ProjectId == projectId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetByStatusAsync(TaskItemStatus status)
        {
            return await _context.TaskItems
                .Where(t => t.Status == status)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(TaskItem task)
        {
            await _context.TaskItems.AddAsync(task);
        }

        public void Update(TaskItem task)
        {
            _context.TaskItems.Update(task);
        }

        public void Delete(TaskItem task)
        {
            _context.TaskItems.Remove(task);
        }
    }
}
