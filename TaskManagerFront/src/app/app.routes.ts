import { Routes } from '@angular/router';
import { Projects } from './components/projects/projects';
import { ProjectForm } from './components/project-form/project-form';
import { Tasks } from './components/tasks/tasks';
import { TaskForm } from './components/task-form/task-form';

export const routes: Routes = [
  {
    path: '',
    component: Projects
  },
  {
    path: 'projects/new',
    component: ProjectForm
  },
  {
    path: 'projects/edit/:id',
    component: ProjectForm
  },
  { path: 'tasks', component: Tasks },
  { path: 'tasks/new', component: TaskForm },
  { path: 'tasks/edit/:id', component: TaskForm },
];