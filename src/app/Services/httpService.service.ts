import { Course } from './../Models/Course.model';
import { Student } from './../Models/Student.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StudentCourse } from '../Models/StudentCourse.model';

@Injectable({providedIn: 'root'})
export class HttpService {
    baseUrl="http://localhost:62806";
    constructor(private httpClient:HttpClient) { }

    getStudents(url:string){
       return this.httpClient.get<Student[]>(this.baseUrl+url,{
            observe:'response'
        })
    }
    postStudent(url:string,student:Student){
        return this.httpClient.post<Student>(this.baseUrl+url,student,{
            observe:'response'})
    }
    getCourses(url:string){
        return this.httpClient.get<Course[]>(this.baseUrl+url,{
             observe:'response'
         })

     }
     postCourse(url:string,student:Student){
        return this.httpClient.post<Course>(this.baseUrl+url,student,{
            observe:'response'})
    }
    getStudentCourses(url:string){
        return this.httpClient.get<StudentCourse[]>(this.baseUrl+url,{
             observe:'response'
         })

     }
     postStudentCourse(url:string,studentCourse:StudentCourse){
        return this.httpClient.post<StudentCourse>(this.baseUrl+url,studentCourse,{
            observe:'response'})
    }






}