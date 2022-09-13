import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject, tap  } from 'rxjs';
import { Course } from 'src/model/course';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private apiUrl = 'http://localhost:7171/courses';
  
  private _refreshrequired=new Subject<void>();
  get RequiredRefresh(){
    return this._refreshrequired;
  }

  constructor(private http: HttpClient) { }

  getCourses(): Observable<Course[]>{
    return this.http.get<Course[]>(this.apiUrl)
  }

  deleteCourse(course: Course): Observable<Course> {
    const url = `${this.apiUrl}/${course.id}`;
    return this.http.delete<Course>(url); 
  }

  updateCourse(course: Course): Observable<Course> {
    const url = `${this.apiUrl}/${course.id}`;
    return this.http.put<Course>(url, course, httpOptions);
  }

  addCourse(course: Course): Observable<Course> {
    return this.http.post<Course>(this.apiUrl, course, httpOptions);
  }

  saveCourse(inputdata:any){
    return this.http.post(this.apiUrl,inputdata).pipe(
      tap(()=>{
        this.RequiredRefresh.next();
      })
    );
  }

}
