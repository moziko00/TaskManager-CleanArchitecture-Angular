export interface TaskItem {
  id: number;
  title: string;
  description?: string;
  status: number;
  dueDate: string;
  projectId: number;
  projectName: string;
}