import { Component, OnInit, ElementRef, ViewChild, NgZone } from '@angular/core';
import { IStudent } from '../../models/student';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastyService } from 'ng2-toasty';
import { StudentService } from '../../services/student.service';
import { PhotoService } from '../../services/photo.service';
import { ProgressService } from '../../services/progress.service';

@Component({
  selector: 'app-view-student',
  templateUrl: './view-student.component.html',
  styleUrls: ['./view-student.component.css']
})
export class ViewStudentComponent implements OnInit {
  student: IStudent;
  studentId: number;
  photos: any[];
  progress: any;

  @ViewChild("fileInput") fileInput: ElementRef;
  
  constructor(
    private zone: NgZone,
    private route: ActivatedRoute,
    private router: Router,
    private toastyService: ToastyService,
    private studentService: StudentService,
    private photoService: PhotoService,
    private progressService: ProgressService) { 

      route.params.subscribe(p => {
        this.studentId = +p.id;
        if (isNaN(this.studentId) || this.studentId <= 0) {
          router.navigate(['/students']);
          return;
        }
      })
  }
    
  ngOnInit() {
    this.photoService.getPhotos(this.studentId)
      .subscribe(photos => this.photos = photos);

    this.studentService.getStudent(this.studentId)
      .subscribe(
        s => this.student = s,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/students']);
            return;
          }
        }
      )
  }

  uploadPhoto() {
    debugger;
    this.progressService.startTracking()
      .subscribe(progress => {
        console.log(progress);
        this.zone.run(() => {
          this.progress = progress;
        });
      },
      err => {
        console.log(err);
      },
      () => {
        this.progress = null;
      });


    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    var file = nativeElement.files![0];
    nativeElement.value = '';
    this.photoService.upload(this.studentId, file)
      .subscribe(photo => {
        this.photos.push(photo);
      },
      err => {
        this.toastyService.error({
          title: "Errors",
          msg: err.text(),
          theme: 'material',
          showClose: true,
          timeout: 5000
        });
      });
  }

}
