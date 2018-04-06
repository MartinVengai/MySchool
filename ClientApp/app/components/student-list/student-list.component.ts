import { IStudent } from './../../models/student';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild, AfterViewInit, ElementRef } from "@angular/core";
import { StudentService } from "../../services/student.service";
import { MatTableDataSource } from "@angular/material/table";
import { DataSource } from "@angular/cdk/collections";
import { CollectionViewer } from "@angular/cdk/collections";
import { Observable } from "rxjs/Observable";
import { fromEvent } from "rxjs/Observable/fromEvent";
import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { catchError, finalize, delay, tap, distinctUntilChanged, debounceTime } from "rxjs/operators";
import {merge} from "rxjs/observable/merge";
import { of } from "rxjs/observable/of";
import { MatSort } from "@angular/material/sort";
import { MatPaginator } from "@angular/material/paginator";

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
  styleUrls: ["./student-list.component.css"]
})
export class StudentListComponent implements OnInit, AfterViewInit {
  studentsCount: number;
  filter: IFilter = { 
    page: 0,
    pageSize:5,
    isSortAscending: true,
    sortBy: "",
    search: ""
  }
  student: IStudent;
  dataSource: StudentDataSource;
  displayedColumns = ["firstName", "lastName", "email", "phone", "actions"];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('input') input: ElementRef;

  constructor(private studentService: StudentService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.filter.page = 1;
    this.filter.pageSize = 5;
    this.student = this.route.snapshot.data["student"];
    this.dataSource = new StudentDataSource(this.studentService);
    this.dataSource.loadStudents(this.filter);
  }

  ngAfterViewInit(): void {
    fromEvent(this.input.nativeElement,'keyup')
      .pipe(
        debounceTime(150),
        distinctUntilChanged(),
        tap(() => {
          this.paginator.pageIndex = 0;
          this.loadStudentsPage();
        })
      )
      .subscribe();

    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
        
    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        tap(() => this.loadStudentsPage())
      )
      .subscribe();
  }

  loadStudentsPage() {
    this.filter.search = this.input.nativeElement.value;
    this.filter.sortBy = this.sort.active;
    this.filter.isSortAscending = (this.sort.direction=="asc") ? true : false;
    this.filter.pageSize = this.paginator.pageSize;
    this.filter.page = this.paginator.pageIndex+1;
    console.log(this.filter);
    
    this.dataSource.loadStudents(this.filter);
  }

  onRowClicked(row: any): void {
    console.log("Row clicked: ", row);
}

}

export class StudentDataSource extends DataSource<any> {
  private studentsSubject = new BehaviorSubject<IStudent[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private studentsCountSubject = new BehaviorSubject<number>(0);

  public loading$ = this.loadingSubject.asObservable();
  public studentsCount$ = this.studentsCountSubject.asObservable();

  constructor(private studentService: StudentService) {
    super();
  }

  connect(collectionViewer: CollectionViewer): Observable<IStudent[]> {
    return this.studentsSubject.asObservable();
  }
  
  disconnect(collectionViewer: CollectionViewer): void {
    this.studentsSubject.complete();
    this.loadingSubject.complete();
    this.studentsCountSubject.complete();
  }

  loadStudents(filter: IFilter) {
    this.loadingSubject.next(true);

    this.studentService.getStudents(filter)
    .pipe(
        catchError(() => of([])),
        finalize(() => this.loadingSubject.next(false))
      )
    .subscribe(
      result => {
        this.studentsSubject.next(result.items);
        this.studentsCountSubject.next(result.totalItems);
      }
    );
  }
}

export interface IFilter {
  search: string;
  sortBy: string;
  isSortAscending: boolean;
  page: number;
  pageSize: number;
}
