import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{HttpClientModule,HTTP_INTERCEPTORS} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { StudentCourseComponent } from './student-course/student-course.component';
import { CourseComponent } from './course/course.component';
import { StudentComponent } from './student/student.component';
import { FormsModule, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { HousingComponent } from './housing/housing.component';
import { CarouselComponent } from './carousel/carousel.component';
import { IvyCarouselModule } from 'angular-responsive-carousel';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    StudentCourseComponent,
    CourseComponent,
    StudentComponent,
    HomeComponent,
    HousingComponent,
    CarouselComponent,    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    IvyCarouselModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
