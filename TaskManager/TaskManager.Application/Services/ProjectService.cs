using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.DTOs.Project;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.Persistence;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _projectRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }
        public async Task<ProjectDto?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid Project Id");

            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return null;

            return _mapper.Map<ProjectDto>(project);
        }
        public async Task AddAsync(CreateProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);

            project.CreatedAt = DateTime.Now;

            await _projectRepository.AddAsync(project);

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, UpdateProjectDto dto)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                throw new KeyNotFoundException("Project not found.");
            _mapper.Map(dto, project);

            _projectRepository.Update(project);

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                throw new KeyNotFoundException("Project not found.");

            _projectRepository.Delete(project);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
