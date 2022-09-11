import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Workload } from 'src/model/workload';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root'
})
export class WorkloadService {

  private apiUrl = 'http://localhost:5000/workload';
  
  constructor(private http: HttpClient) { }

  getWorkload(): Observable<Workload[]>{
    return this.http.get<Workload[]>(this.apiUrl)
  }

  deleteWorkload(workload: Workload): Observable<Workload> {
    const url = `${this.apiUrl}/${workload.id}`;
    return this.http.delete<Workload>(url); 
  }

  updateWorkload(workload: Workload): Observable<Workload> {
    const url = `${this.apiUrl}/${workload.id}`;
    return this.http.put<Workload>(url, workload, httpOptions);
  }

  addWorkload(workload: Workload): Observable<Workload> {
    return this.http.post<Workload>(this.apiUrl, workload, httpOptions);
  }
}
