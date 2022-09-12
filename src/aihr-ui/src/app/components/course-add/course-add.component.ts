import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { WebService } from 'src/app/services/web.service';
import { Subscription } from 'rxjs';
import { Course } from 'src/model/course';

@Component({
  selector: 'app-course-add',
  templateUrl: './course-add.component.html',
  styleUrls: ['./course-add.component.scss']
})
export class CourseAddComponent implements OnInit {

  @Output() onAddCourse: EventEmitter<Course> = new EventEmitter();
  name: string = '';
  hours: number = 0;
  showAddCourse: boolean = false;
  subscription: Subscription;
  constructor(private webService: WebService) { 
    this.subscription = this.webService
    .onToggle()
    .subscribe((value) => (this.showAddCourse = value));
  }

  ngOnInit(): void {
  }

  ngOnDestroy() {
    // Unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
}



  onSubmit() {
    if (!this.name) {
      alert('Please add a Course!');
      return;
    }

    const newCourse: Course = {
      name: this.name,
      hours: this.hours,
    };

    this.onAddCourse.emit(newCourse);

    this.name = '';
    this.hours = 0;
  }

}
