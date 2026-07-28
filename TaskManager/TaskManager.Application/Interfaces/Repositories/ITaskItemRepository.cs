using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Interfaces.Repositories
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();

        Task<TaskItem?> GetByIdAsync(int id);

        Task<IEnumerable<TaskItem>> GetByProjectIdAsync(int projectId);

        Task<IEnumerable<TaskItem>> GetByStatusAsync(TaskItemStatus status);

        Task AddAsync(TaskItem task);

        void Update(TaskItem task);

        void Delete(TaskItem task);
    }
}
