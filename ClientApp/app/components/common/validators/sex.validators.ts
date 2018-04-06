import { AbstractControl, ValidationErrors } from "@angular/forms";

export class SexValidators {
  static validSex(control: AbstractControl): ValidationErrors | null {
    if ((control.value as string) === "Male" || (control.value as string) === "Female") {
      return null;
    }
    return { validSex: true };
  }
}