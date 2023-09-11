import { Driver } from "./driver";
import { Vehicle } from "./vehicle";

export class Quote {
    quoteId: number;
    agentId: string;
    isSubmitted: boolean;
    deviceType: string;
    creationDate: Date;
    submissionDate: Date;
    policyHolderFName: string;
    policyHolderLName: string;
    addressLine1: string;
    addressLine2: string;
    city: string;
    state: string;
    postalCode: string;
    policyHolderSsn: string;
    policyHolderDOB: Date;
    lessThan3YearsDriving: boolean;
    previousCarrier: boolean;
    movingViolationInLast5Years: boolean;
    claimInLast5Years: boolean;
    forceMultiCarDiscount: boolean;
    quotePrice: number;
    drivers: Driver[];
    vehicles: Vehicle[];

    constructor() {
        this.drivers = [];
        this.vehicles = [];
    }
}