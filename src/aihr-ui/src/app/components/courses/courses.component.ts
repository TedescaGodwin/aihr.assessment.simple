import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Course } from 'src/model/course';
import { CourseService } from 'src/app/services/course.service';
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as alertify from 'alertifyjs'

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {

  constructor(private courseService: CourseService, public dialogref: MatDialogRef<CoursesComponent>,@Inject(MAT_DIALOG_DATA) public data:any) { }

  courseLibrary: any;
  response: any;
  editCourse: any;


  ngOnInit(): void {
    this.loadCourse();
    if(this.data.empcode!=null && this.data.empcode!=''){
      this.LoadEditCourse(this.data.empcode);
    }
  }

  LoadEditCourse(course: Course) {
    this.courseService.updateCourse(course).subscribe(item => {
      this.editCourse = item;
      this.Reactiveform.setValue(
                  { name: this.editCourse.name,
                    hours: this.editCourse.hours})
    });
  }

  Reactiveform = new FormGroup({
    name: new FormControl("", Validators.required),
    hours: new FormControl("", Validators.required),
  });

  loadCourse() {
    this.courseService.getCourses().subscribe((courses) => {
      this.courseLibrary = courses;
    });
  }

  SaveCourse() {
    if (this.Reactiveform.valid) {

      let course: Course = {
        name: this.Reactiveform.value.name!,
        hours: Number.parseFloat(this.Reactiveform.value.hours!),
      };

      this.courseService.addCourse(course).subscribe(result => {
        this.response = result;
        if (this.response.result == 'pass') {
          alertify.success("saved successfully.")
          this.dialogref.close();
        }
      });

    } else {
      alertify.error("Please Enter valid data")
    }
  }
}
