import { Student } from './../Models/Student.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StudentCourse } from '../Models/StudentCourse.model';
import { HttpService } from '../Services/httpService.service';
import { Course } from '../Models/Course.model';

@Component({
  selector: 'app-student-course',
  templateUrl: './student-course.component.html',
  styleUrls: ['./student-course.component.scss']
})
export class StudentCourseComponent implements OnInit {
  studentCourses:StudentCourse[]|null=[];
  students:Student[]|null=[];
  courses:Course[]|null=[];
  userFormGroup: FormGroup;
  x:any;

  message="";
  constructor(private httpService:HttpService,private formBuilder:FormBuilder) { 
    this.userFormGroup=this.formBuilder.group({
      'studentId':[null,Validators.required],
      'courseId': [null,Validators.required]
    })
  }
  ngOnInit(): void {
    this.httpService.getStudentCourses('/api/StudentCourse').subscribe(res => {
      this.studentCourses=res.body
    })
    this.httpService.getCourses('/api/Courses').subscribe(res => {
      this.courses=res.body
    })
    this.httpService.getStudents('/api/Students').subscribe(res => {
      this.students=res.body
    })
  }
  onSubmit(){
    //const j:StudentCourse={studentId:this.userFormGroup.value,courseId}
    this.httpService.postStudentCourse('/api/StudentCourse',this.userFormGroup.value).subscribe(res=>{
      this.x=res.body
      console.log(this.userFormGroup.value);
    })
    this.message="Student was Registered Successfully ✔️";
  }
  

 
 

}

