using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.DTOs.TaskItem;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Interfaces.Services
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItemDto>> GetAllAsync();

        Task<TaskItemDto?> GetByIdAsync(int id);

        Task<IEnumerable<TaskItemDto>> GetByProjectIdAsync(int projectId);

        Task<IEnumerable<TaskItemDto>> GetByStatusAsync(TaskItemStatus status);

        Task AddAsync(CreateTaskItemDto dto);

        Task UpdateAsync(int id, UpdateTaskItemDto dto);

        Task DeleteAsync(int id);
    }
}
