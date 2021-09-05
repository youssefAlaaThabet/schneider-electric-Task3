import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Course } from '../Models/Course.model';
import { HttpService } from '../Services/httpService.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  userFormGroup: FormGroup;
  courses:Course[]|null=[];
  constructor(private httpService:HttpService,private formBuilder:FormBuilder) { 
    this.userFormGroup=this.formBuilder.group({
      'name':[null,Validators.required]
    })
  }

  ngOnInit(): void {
    this.httpService.getCourses('/api/Courses').subscribe(res => {
      this.courses=res.body
    })
  }
  message:String="";
  x:any;

  onSubmit(){
    if (this.userFormGroup.value.name!=null){

    this.httpService.postCourse('/api/Courses',this.userFormGroup.value).subscribe(res=>{
      this.x=res.body
    })
    this.userFormGroup.reset();
    this.message="Student was Added Successfully ✔️";
  }
  }
  

}
