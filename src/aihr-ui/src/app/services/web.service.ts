import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WebService {
  private showAddCourse: boolean = false;
  private subject = new Subject<any>();
  constructor() { }

  toggleAddCourse(): void {
    this.showAddCourse = !this.showAddCourse;
    this.subject.next(this.showAddCourse);
  }

  onToggle(): Observable<any> {
    return this.subject.asObservable();
  }
}
