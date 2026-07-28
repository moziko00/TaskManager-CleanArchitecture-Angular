using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTOs.TaskItem
{
    public class TaskItemDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public TaskItemStatus Status { get; set; }

        public DateTime DueDate { get; set; }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;

    }
}
