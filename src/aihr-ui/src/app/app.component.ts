
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import * as alertify from 'alertifyjs'
import { Course } from 'src/model/course';
import { CoursesComponent } from './components/courses/courses.component';
import { CourseService } from './services/course.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'aihr-ui';
  displayedColumns: string[] = ['name', 'hours'];
  dataSource: any;
  coursedata: any;

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  constructor(private courseService: CourseService, private dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.GetAll();
    this.courseService.RequiredRefresh.subscribe(r => {
      this.GetAll();
    });
  }

  GetAll() {
    this.courseService.getCourses().subscribe(courses => {
      this.coursedata.result = courses;

      this.dataSource = new MatTableDataSource<Course>(this.coursedata)
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  Filterchange(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filvalue;
  }

  getrow(row: any) {
    //console.log(row);
  }
  FunctionEdit(code: any) {
    this.OpenDialog('1000ms','600ms',code)
  }

  FunctionDelete(course: any) {
    alertify.confirm("Remove Course","Do you want to remove?",()=>{
      this.courseService.deleteCourse(course).subscribe(result => {
        this.GetAll();
        alertify.success("Removed successfully.")
      });

    },function(){

    })
    
  }

  OpenDialog(enteranimation: any, exitanimation: any,course:any) {

    this.dialog.open(CoursesComponent, {
      enterAnimationDuration: enteranimation,
      exitAnimationDuration: exitanimation,
      width: "50%",
      data:{
        results: course  
      }
    })
  }


}
