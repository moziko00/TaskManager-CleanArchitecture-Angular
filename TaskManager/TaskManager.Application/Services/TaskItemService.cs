using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.DTOs.TaskItem;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.Persistence;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskItemService(
            ITaskItemRepository taskRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskItemDto>> GetAllAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TaskItemDto>>(tasks);
        }

        public async Task<TaskItemDto?> GetByIdAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
                return null;

            return _mapper.Map<TaskItemDto>(task);
        }

        public async Task<IEnumerable<TaskItemDto>> GetByProjectIdAsync(int projectId)
        {
            var tasks = await _taskRepository.GetByProjectIdAsync(projectId);

            return _mapper.Map<IEnumerable<TaskItemDto>>(tasks);
        }

        public async Task<IEnumerable<TaskItemDto>> GetByStatusAsync(TaskItemStatus status)
        {
            var tasks = await _taskRepository.GetByStatusAsync(status);

            return _mapper.Map<IEnumerable<TaskItemDto>>(tasks);
        }

        public async Task AddAsync(CreateTaskItemDto dto)
        {
            var task = _mapper.Map<TaskItem>(dto);

            await _taskRepository.AddAsync(task);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateTaskItemDto dto)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
                throw new Exception("Task not found.");

            _mapper.Map(dto, task);

            _taskRepository.Update(task);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
                throw new Exception("Task not found.");

            _taskRepository.Delete(task);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
