import { Driver } from "./driver";

export class Vehicle {
    vehicleId: number;
    vin: string;
    make: string;
    model: string;
    year: number;
    currentValue: number;
    annualMileage: number;
    daytimeRunningLights: boolean;
    antilockBrakes: boolean;
    passiveRestraints: boolean;
    antiTheft: boolean;
    daysDrivenPerWeek: number;
    milesDrivenToWork: number;
    reducedUsedDiscount: boolean;
    garageAddressDifferentFromResidence: boolean;
    quoteMultiplier: number;
    primaryDriverId: number;
    drivers: Driver[];

    constructor() {
        this.drivers = [];
    }
}