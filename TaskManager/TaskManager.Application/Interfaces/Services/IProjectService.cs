using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.DTOs.Project;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync();

        Task<ProjectDto?> GetByIdAsync(int id);

        Task AddAsync(CreateProjectDto dto);

        Task UpdateAsync(int id, UpdateProjectDto dto);

        Task DeleteAsync(int id);
    }
}
