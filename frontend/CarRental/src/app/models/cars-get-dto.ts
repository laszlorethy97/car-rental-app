export interface CarsGetDto {
    id: number;
    licenseplate: string;
    brand: string;
    model: string;
    year: number;
    kilometrage: number;
    rentPrice: number;
    CarStatus: CarStatus;
}

export enum CarStatus {
  Available,
  Unavailable,
  Service 
}