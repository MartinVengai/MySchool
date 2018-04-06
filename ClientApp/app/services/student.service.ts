import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { IStudent, ISaveStudent } from "../models/student";
import "rxjs/add/operator/map";
import { IFilter } from "../components/student-list/student-list.component";

@Injectable()
export class StudentService {
  constructor(private http: Http) { }

  getClasses(): Observable<any> {
    return this.http.get("/api/classes").map(res => res.json());
  }

  create(student: ISaveStudent): Observable<any> {
    return this.http.post("/api/students", student).map(res => res.json());
  }

  getStudent(id: number): Observable<any> {
    return this.http.get("/api/students/" + id).map(res => res.json());
  }

  getStudents(filter: IFilter): Observable<any> {
    return this.http.get("/api/students" + "?" + this.toQueryString(filter)).map(res => res.json());
  }

  update(student: ISaveStudent): Observable<any> {
    return this.http.put("/api/students/" + student.id, student).map(res => res.json());
  }

  private toQueryString(obj) {
    var parts: any[] = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) {
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
      }
    }
    return parts.join('&');
  }
}
