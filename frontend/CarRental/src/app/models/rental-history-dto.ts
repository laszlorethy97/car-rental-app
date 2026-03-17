export interface RentalHistoryDto {
    carId: number;
    brand: string;
    model: string;
    licensePlate:string;
    startDate: Date;
    endDate: Date;
    rentStatus: string;
    rentPrice: number;
}

