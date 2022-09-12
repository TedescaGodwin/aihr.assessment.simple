import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Course } from 'src/model/course';
import { faTimes } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss']
})

export class CourseListComponent implements OnInit {
  @Input() course: Course | undefined;
  @Output() onDeleteCourse: EventEmitter<Course> = new EventEmitter();
  @Output() onToggleCourse: EventEmitter<Course> = new EventEmitter();

  faTimes = faTimes;
  constructor() {}

  ngOnInit(): void {}

  onDelete(course: Course | undefined) {
    this.onDeleteCourse.emit(course);
  }

  onToggle(course: Course | undefined) {
    this.onToggleCourse.emit(course);
  }

}
