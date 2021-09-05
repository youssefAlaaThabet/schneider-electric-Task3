import { Student } from './../Models/Student.model';
import { Component, OnInit } from '@angular/core';
import { HttpService } from '../Services/httpService.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {
  students:Student[]|null=[];
  gpa:number=1;
  name:string="sq";


  Pressed:string="false";
  test:Student[]=[];

  userFormGroup: FormGroup;
  
  constructor(private httpService:HttpService,private formBuilder:FormBuilder) { 
    this.userFormGroup=this.formBuilder.group({
      'name':[null,Validators.required],
      'gpa':[null,Validators.required]
    })
  }

  ngOnInit(): void {
    this.httpService.getStudents('/api/Students').subscribe(res => {
      this.students=res.body
    })
  }

x:any;
message:String="";

  onSubmit(){
    if (this.userFormGroup.value.name!=null && this.userFormGroup.value.gpa!=null 
      && this.userFormGroup.value.gpa<=4 &&this.userFormGroup.value.gpa>=0.7){


    this.httpService.postStudent('/api/Students',this.userFormGroup.value).subscribe(res=>{
      this.x=res.body
    })
    this.userFormGroup.reset();
    this.message="Student was Added Successfully ✔️";
  }
  }
  

}
