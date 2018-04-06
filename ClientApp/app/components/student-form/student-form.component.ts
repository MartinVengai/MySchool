import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl } from "@angular/forms";
import { StudentService } from "../../services/student.service";
import { IdNumberValidators } from "../common/validators/idnumber.validators";
import { SexValidators } from "../common/validators/sex.validators";
import { IKeyValuePair, IClass, IStudent, ISaveStudent } from "../../models/student";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import "rxjs/add/observable/forkJoin";
import { ToastyService } from "ng2-toasty";

@Component({
  selector: "student-form",
  templateUrl: "./student-form.component.html",
  styleUrls: ["./student-form.component.css"]
})
export class StudentFormComponent implements OnInit {
  classes: IClass[];
  classSections: IKeyValuePair[];
  studentForm: FormGroup;
  student: ISaveStudent = {
    id: 0,
    firstName: "",
    lastName: "",
    email: "",
    phone: "",
    classId: 0,
    classSectionId: 0,
    sex: "",
    idNumber: "",
    dateEnrolled: "",
    dateOfBirth: "",
    address: {
      street: "",
      zip: "",
      city: "",
      country: ""
    }
  };

  constructor(
    private toastyService: ToastyService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private studentService: StudentService) {
      this.createStudentForm();

      route.params.subscribe(p => {
        this.student.id = +p.id;
      });
  }

  ngOnInit(): void {
    var sources: any[] = [
      this.studentService.getClasses()
    ];

    if(this.student.id) {
      sources.push(this.studentService.getStudent(this.student.id));
    }

    Observable.forkJoin(sources).subscribe(data => {
      this.classes = data[0] as any[];

      if (this.student.id) {
        this.setStudentForm(data[1] as IStudent);
        this.populateClassSections();
      }
    }, err => {
      if (err.status === 404) {
        this.router.navigate(["/home"]);
      }
    });
  }

  private setStudentForm(s: IStudent): void {
    this.firstName.setValue(s.firstName);
    this.lastName.setValue(s.lastName);
    this.email.setValue(s.email);
    this.phone.setValue(s.phone);
    this.sex.setValue(s.sex);
    this.idNumber.setValue(s.idNumber);
    this.dateOfBirth.setValue(s.dateOfBirth);
    this.dateEnrolled.setValue(s.dateEnrolled);
    this.classId.setValue(s.class.id);
    this.classSectionId.setValue(s.classSection.id);
    this.street.setValue(s.address.street);
    this.city.setValue(s.address.city);
    this.zip.setValue(s.address.zip);
    this.country.setValue(s.address.country);
  }


  populateClasses(): void {
    this.studentService.getClasses().subscribe(classes => this.classes = classes);
  }

 onClassChange(): void {
   this.populateClassSections();
   this.classSectionId.setValue(null);
 }

 private populateClassSections(): void {
  var selectedClass: IClass | undefined = this.classes.find(c => c.id === this.classId.value);
  this.classSections = selectedClass ? selectedClass.classSections : [];
 }

  createStudentForm(): void {
    this.studentForm = this.fb.group({
      firstName: ["", [Validators.required, Validators.minLength(3), Validators.maxLength(255)]],
      lastName: ["", [Validators.required, Validators.minLength(3), Validators.maxLength(255)]],
      email: ["", [Validators.required, Validators.email, Validators.maxLength(255)]],
      phone: ["", [Validators.maxLength(10)]],
      sex: ["", [Validators.required, SexValidators.validSex]],
      idNumber: ["",[Validators.required, Validators.minLength(4), Validators.maxLength(244)], IdNumberValidators.shouldBeUnique],
      dateOfBirth: ["", [Validators.required]],
      dateEnrolled: ["", [Validators.required]],
      classId: ["", Validators.required],
      classSectionId: ["", Validators.required],
      address: this.fb.group({
        street: ["", [Validators.required, Validators.minLength(3), Validators.maxLength(255)]],
        city: ["", [Validators.minLength(3), Validators.maxLength(255)]],
        country: ["", [Validators.minLength(2),Validators.maxLength(255)]],
        zip: ["", [Validators.minLength(2), Validators.maxLength(10)]]
      })
    });
  }

  submit(): void {
    if (this.studentForm.valid) {

      var result$;

      if (this.student.id) {
        var studentId: number = this.student.id;
        this.student = this.studentForm.value;
        this.student.id = studentId;
        result$ = this.studentService.update(this.student);
      } else {
        this.student = this.studentForm.value;
        result$ = this.studentService.create(this.student);
      }

      result$.subscribe(student => {
        this.toastyService.success({
          title: "Success",
          msg: "Student data successfully saved.",
          theme: "material",
          showClose: true,
          timeout: 5000
        });
        this.router.navigate(['/students/view', student.id]);
      })

    } else {
      this.validateAllFormFields(this.studentForm);
    }
  }

  validateAllFormFields(formGroup: FormGroup): void {
    Object.keys(formGroup.controls).forEach(field => {
      const control: AbstractControl | null = formGroup.get(field);

      if (control instanceof FormControl) {
        control.markAsTouched({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      }
    });
  }


  get classId(): FormControl {
    return this.studentForm.get("classId") as FormControl;
  }
  get classSectionId(): FormControl {
    return this.studentForm.get("classSectionId") as FormControl;
  }
  get firstName(): FormControl {
    return this.studentForm.get("firstName") as FormControl;
  }
  get lastName(): FormControl {
    return this.studentForm.get("lastName") as FormControl;
  }
  get email(): FormControl {
    return this.studentForm.get("email") as FormControl;
  }
  get phone(): FormControl {
    return this.studentForm.get("phone") as FormControl;
  }
  get sex(): FormControl {
    return this.studentForm.get("sex") as FormControl;
  }
  get idNumber(): FormControl {
    return this.studentForm.get("idNumber") as FormControl;
  }
  get dateOfBirth(): FormControl {
    return this.studentForm.get("dateOfBirth") as FormControl;
  }
  get dateEnrolled(): FormControl {
    return this.studentForm.get("dateEnrolled") as FormControl;
  }
  get street(): FormControl {
    return this.studentForm.get("address.street") as FormControl;
  }
  get city(): FormControl {
    return this.studentForm.get("address.city") as FormControl;
  }
  get country(): FormControl {
    return this.studentForm.get("address.country") as FormControl;
  }
  get zip(): FormControl {
    return this.studentForm.get("address.zip") as FormControl;
  }
}
