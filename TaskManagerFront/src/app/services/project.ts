import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project } from '../models/project.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private apiUrl = 'https://localhost:7085/api/Projects';

  constructor(private http: HttpClient) {}

  getAllProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl);
  }
   createProject(project: any): Observable<any> {
    return this.http.post(this.apiUrl, project);
   }
   getProjectById(id: number): Observable<Project> {
  return this.http.get<Project>(`${this.apiUrl}/${id}`);
}

updateProject(id: number, project: any): Observable<any> {
  return this.http.put(`${this.apiUrl}/${id}`, project);
}
deleteProject(id: number): Observable<any> {
  return this.http.delete(`${this.apiUrl}/${id}`);
}
}