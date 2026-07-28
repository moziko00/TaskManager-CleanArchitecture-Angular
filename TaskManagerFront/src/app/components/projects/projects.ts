import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import { Project } from '../../models/project.model';
import { ProjectService } from '../../services/project';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './projects.html',
  styleUrl: './projects.css'
})
export class Projects implements OnInit {

  projects: Project[] = [];

  constructor(private projectService: ProjectService) {}

  ngOnInit(): void {

  console.log('Component Loaded');

  this.projectService.getAllProjects().subscribe({
    next: (data) => {
      console.log('API Response:', data);
      this.projects = data;
      console.log('Projects Variable:', this.projects);
    },
    error: (err) => {
      console.error('API Error:', err);
    }
  });

}
deleteProject(id: number) {

  if (!confirm('Are you sure you want to delete this project?')) {
    return;
  }

  this.projectService.deleteProject(id).subscribe({
    next: () => {
      this.projects = this.projects.filter(p => p.id !== id);
      alert('Project deleted successfully');
    },
    error: err => console.error(err)
  });

}
}