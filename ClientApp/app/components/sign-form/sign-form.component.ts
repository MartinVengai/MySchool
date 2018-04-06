import { Component, OnInit } from "@angular/core";
import {FormControl, Validators, FormGroupDirective, NgForm} from "@angular/forms";
import { ErrorStateMatcher } from "@angular/material/core";



@Component({
  selector: "app-sign-form",
  templateUrl: "./sign-form.component.html",
  styleUrls: ["./sign-form.component.css"]
})
export class SignFormComponent {
  emailFormControl = new FormControl("", [
    Validators.required,
    Validators.email,
  ]);
  sex = new FormControl("", [
    Validators.required
  ]);

  matcher = new MyErrorStateMatcher();
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted: Boolean | null = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}