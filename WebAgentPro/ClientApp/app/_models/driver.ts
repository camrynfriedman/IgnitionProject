import { Vehicle } from "./vehicle";

export class Driver {
    driverId: number;
    driverName: string;
    driverSSN: string;
    driverLicenseNumber: string;
    driverLicenseState: string;
    driverDOB: Date;
    safeDrivingSchool: boolean;
    quoteMultiplier: number;
    quoteId: number;
    vehicles: Vehicle[];

    constructor() {
        this.vehicles = [];
    }
}