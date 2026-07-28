using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTOs.TaskItem
{
    public class UpdateTaskItemDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [StringLength(500)]
        public string? Description { get; set; }
        [Required]
        public TaskItemStatus Status { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}
