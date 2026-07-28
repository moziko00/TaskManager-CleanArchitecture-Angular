import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { TaskService } from '../../services/task';
import { ProjectService } from '../../services/project';

import { Project } from '../../models/project.model';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './task-form.html',
  styleUrl: './task-form.css'
})
export class TaskForm implements OnInit {

  taskForm!: FormGroup;
  projects: Project[] = [];
  isEdit = false;
  taskId = 0;

  constructor(
    private fb: FormBuilder,
    private taskService: TaskService,
    private projectService: ProjectService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {

    this.taskForm = this.fb.group({
      title: ['', Validators.required],
      description: [''],
      status: [0, Validators.required],
      dueDate: ['', Validators.required],
      projectId: ['', Validators.required]
    });

    this.loadProjects();

    this.route.params.subscribe(params => {

      if (params['id']) {
        this.isEdit = true;
        this.taskId = +params['id'];
        this.loadTask();
      }

    });

  }

  loadProjects() {

    this.projectService.getAllProjects().subscribe({
      next: data => this.projects = data,
      error: err => console.log(err)
    });

  }

  loadTask() {

    this.taskService.getTaskById(this.taskId).subscribe({

      next: (task) => {

        this.taskForm.patchValue({
          title: task.title,
          description: task.description,
          status: task.status,
          dueDate: task.dueDate.substring(0, 10),
          projectId: task.projectId
        });

      },

      error: err => console.log(err)

    });

  }

  saveTask() {

    if (this.taskForm.invalid) {
      this.taskForm.markAllAsTouched();
      return;
    }

    const task = {
      ...this.taskForm.value,
      status: Number(this.taskForm.value.status),
      projectId: Number(this.taskForm.value.projectId)
    };

    if (this.isEdit) {

      this.taskService.updateTask(this.taskId, task).subscribe({

        next: () => {
          alert('Task Updated Successfully');
          this.router.navigate(['/tasks']);
        },

        error: err => {
          console.log(err);
          alert('Error Updating Task');
        }

      });

    } else {

      this.taskService.createTask(task).subscribe({

        next: () => {
          alert('Task Created Successfully');
          this.router.navigate(['/tasks']);
        },

        error: err => {
          console.log(err);
          alert('Error Creating Task');
        }

      });

    }

  }

}