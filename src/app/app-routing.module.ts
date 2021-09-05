import { StudentCourseComponent } from './student-course/student-course.component';
import { CourseComponent } from './course/course.component';
import { StudentComponent } from './student/student.component';
import { Student } from './Models/Student.model';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'Student',component:StudentComponent},
  {path:'Course',component:CourseComponent},
  {path:'StudentCourse',component:StudentCourseComponent},
  {path:'**',redirectTo:'/' ,pathMatch:'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
