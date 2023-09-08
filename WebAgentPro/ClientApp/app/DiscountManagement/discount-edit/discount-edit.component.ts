import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from '@environments/environment';

import { Discount } from '@app/_models/discount';

@Component({
    templateUrl: './discount-edit.component.html'
})
export class DiscountEditComponent implements OnInit {

    apiUrl: string = environment.apiUrl
    stateParamSubscription: Subscription

    action: string
    discount: Discount;

    form: FormGroup
    stepValue: number = 0.01;

    constructor(private route: ActivatedRoute, private http: HttpClient, private router: Router) { }

    ngOnInit(): void {
        this.stateParamSubscription = this.route.params.subscribe(
            params => {
                this.action = params['action']
                console.log(this.action);

                const initializeState = params['state']
                console.log(initializeState);

                switch (this.action) {
                    case "add":
                        this.initializeDiscount(params['state'])
                        break;
                    case "edit":
                        this.getDiscount(params['state'])
                        break;
                }
                this.form = new FormGroup(
                    {
                        state:
                            new FormControl({ value: this.discount.state, disabled: true }, Validators.required),
                        daytimeRunningLights:
                            new FormControl('', Validators.required),
                        antilockBrakes:
                            new FormControl('', Validators.required),
                        lowAnnualMileage:
                            new FormControl('', Validators.required),
                        passiveRestraints:
                            new FormControl('', Validators.required),
                        antitheftInstalled:
                            new FormControl('', Validators.required),
                        highDaysDrivenPerWeek:
                            new FormControl('', Validators.required),
                        lowMilesDrivenToWork:
                            new FormControl('', Validators.required),
                        reduceUse:
                            new FormControl('', Validators.required),
                        garageAddressDifferent:
                            new FormControl('', Validators.required),
                        lowDrivingExperience:
                            new FormControl('', Validators.required),
                        previousCarrierLizard:
                            new FormControl('', Validators.required),
                        previousCarrierPervasive:
                            new FormControl('', Validators.required),
                        recentMovingViolations:
                            new FormControl('', Validators.required),
                        recentClaims:
                            new FormControl('', Validators.required),
                        multiCar:
                            new FormControl('', Validators.required),
                        youngDriver:
                            new FormControl('', Validators.required),
                        safeDrivingSchool:
                            new FormControl('', Validators.required),
                    }
                );
            }
        )
    }

    ngOnDestroy() {
        this.stateParamSubscription.unsubscribe();
    }

    onSubmit() {
        if (this.form.valid) {
            this.form.value.state = this.discount.state;
            switch (this.action) {
                case "add":
                    this.postDiscount(this.form.value)
                    break
                case "edit":
                    this.putDiscount(this.form.value)
                    break
            }
        }
    }

    initializeDiscount(state: string) {
        this.discount = new Discount
        this.discount.state = state
    }

    // #region API Calls

    getDiscount(state: string) {
        var httpRequest = this.http.get<Discount>(`${this.apiUrl}/discounts/${state}`)

        httpRequest.subscribe(
            returnedDiscount => {
                this.discount = returnedDiscount
            })
    }

    putDiscount(updatedDiscount: Discount) {
        var httpRequest = this.http.put(`${this.apiUrl}/discounts/${updatedDiscount.state}`, updatedDiscount)

        httpRequest.subscribe(
            success => {
                this.router.navigateByUrl("/discounts")
            })
    }

    postDiscount(newDiscount: Discount) {
        var httpRequest = this.http.post<number>(`${this.apiUrl}/discounts`, newDiscount)

        httpRequest.subscribe(
            success => {
                this.router.navigateByUrl("/discounts")
            })
    }

    // #endregion
}
