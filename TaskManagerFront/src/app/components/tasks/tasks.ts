import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import { TaskService } from '../../services/task';
import { TaskItem } from '../../models/task-item.model';

@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './tasks.html',
  styleUrl: './tasks.css'
})
export class Tasks implements OnInit {

  tasks: TaskItem[] = [];

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {

    this.taskService.getAllTasks().subscribe({
      next: (data) => {
        this.tasks = data;
        console.log(data);
      },
      error: (err) => console.error(err)
    });

  }

  getStatusName(status: number): string {

    switch (status) {

      case 0:
        return 'Pending';

      case 1:
        return 'In Progress';

      case 2:
        return 'Completed';

      default:
        return 'Unknown';
    }

  }
deleteTask(id: number) {

  if (!confirm('Are you sure you want to delete this task?')) {
    return;
  }

  this.taskService.deleteTask(id).subscribe({

    next: () => {

      this.tasks = this.tasks.filter(t => t.id !== id);

      alert('Task Deleted Successfully');

    },

    error: err => {
      console.log(err);
      alert('Error Deleting Task');
    }

  });

}
}