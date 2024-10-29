export interface Client {
  identificationNumber: string,
  fullName: string,
  age: number,
  phoneNumber: string
}

export interface ClientInput {
  identificationNumber: string,
  names: string,
  lastNames: string,
  age: number | string,
  phoneNumber: string
}