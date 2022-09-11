import { Component, OnInit } from '@angular/core';
import { Course } from 'src/model/course';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {
  courses: Course[] =[];
  constructor(private courseService: CourseService) { }

  ngOnInit(): void {
    this.courseService.getCourses().subscribe((courses) => (this.courses = courses ))
  }

  deleteTask(course: Course) {
    this.courseService
      .deleteCourse(course)
      .subscribe(
        () => (this.courses = this.courses.filter((c) => c.id !== course.id))
      );
  }

  addCourse(course: Course) {
    this.courseService.addCourse(course).subscribe((course) => this.courses.push(course));
  }

}
