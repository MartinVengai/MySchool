export interface IKeyValuePair {
  id: number;
  name: string;
}

export interface IClass {
  id: number;
  name: string;
  classSections: IKeyValuePair[];
}

export interface IAddress {
  street: string;
  city: string;
  country: string;
  zip: string;
}

export interface IStudent {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  sex: string;
  idNumber: string;
  dateOfBirth: string;
  dateEnrolled: string;
  class: IKeyValuePair;
  classSection: IKeyValuePair;
  address: IAddress;
}

export interface ISaveStudent {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  idNumber: string;
  sex: string;
  dateOfBirth: string;
  dateEnrolled: string;
  classId: number;
  classSectionId: number;
  address: IAddress;
}