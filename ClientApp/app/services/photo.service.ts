import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class PhotoService {

  constructor(private http: Http) { }

  upload(studentId, photo) {
    var formData = new FormData();
    formData.append("file", photo);
    return this.http.post(`/api/students/${studentId}/photos`, formData)
    .map(res => res.json());
  }

  getPhotos(studentId) {
    return this.http.get(`/api/students/${studentId}/photos`)
      .map(res => res.json());
  }
}