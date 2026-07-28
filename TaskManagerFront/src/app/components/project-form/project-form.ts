import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { ProjectService } from '../../services/project';

@Component({
  selector: 'app-project-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './project-form.html',
  styleUrl: './project-form.css'
})
export class ProjectForm implements OnInit {

  id = 0;
  isEdit = false;

  project = {
    name: '',
    description: ''
  };

  constructor(
    private projectService: ProjectService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

ngOnInit(): void {

  console.log('URL:', this.router.url);

  this.id = Number(this.route.snapshot.paramMap.get('id'));

  console.log('ID:', this.id);

  if (this.id) {

    this.isEdit = true;

    this.projectService.getProjectById(this.id).subscribe({
      next: (data) => {

        console.log('Project Data:', data);

        this.project.name = data.name;
        this.project.description = data.description;

      },
      error: (err) => console.error(err)
    });

  }

}

  saveProject() {

    if (this.isEdit) {

      this.projectService.updateProject(this.id, this.project).subscribe({
        next: () => {

          alert('Project Updated Successfully');
          this.router.navigate(['/']);

        }
      });

    }
    else {

      this.projectService.createProject(this.project).subscribe({
        next: () => {

          alert('Project Added Successfully');
          this.router.navigate(['/']);

        }
      });

    }

  }

}