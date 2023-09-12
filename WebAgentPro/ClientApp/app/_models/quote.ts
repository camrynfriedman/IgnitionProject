import { Driver } from "./driver";
import { Vehicle } from "./vehicle";

export class Quote {
    quoteId:
        number = 0;
    agentId:
        string = '';
    isSubmitted:
        boolean = false;
    deviceType:
        string = '';
    creationDate:
        Date = new Date();
    submissionDate:
        Date = new Date();
    policyHolderFName:
        string = '';
    policyHolderLName:
        string = '';
    addressLine1:
        string = '';
    addressLine2:
        string = '';
    city:
        string = '';
    state:
        string = '';
    postalCode:
        string = '';
    policyHolderSsn:
        string = '';
    policyHolderDOB:
        Date = new Date();
    lessThan3YearsDriving:
        boolean = false;
    previousCarrier:
        string = '';
    movingViolationInLast5Years:
        boolean = false;
    claimInLast5Years:
        boolean = false;
    forceMultiCarDiscount:
        boolean = false;
    quotePrice:
        number = 0;
    policyHolderEmailAddress:
        string = '';
    policyHolderPhoneNumber:
        string = '';
    drivers:
        Driver[];
    vehicles:
        Vehicle[];

    constructor(data?: Partial<Quote>) {
        this.drivers = [];
        this.vehicles = [];

        if (data) {
            Object.assign(this, data);
        }
    }
}