import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from '@environments/environment';

import { Quote } from '@app/_models/quote';
import { Driver } from '@app/_models/driver';

@Component({
    templateUrl: './customer-info1.component.html',
    styleUrls: ['./customer-info1.component.css']
})
export class CustomerInfo1Component implements OnInit {

    apiUrl: string = environment.apiUrl

    //driver: Driver;

    form: FormGroup

    constructor(private route: ActivatedRoute, private http: HttpClient, private router: Router) { }

    ngOnInit(): void {
        this.form = new FormGroup({
            firstName:
                new FormControl('', Validators.required),
            lastName:
                new FormControl('', Validators.required),
            dob:
                new FormControl('', Validators.required),
            country:
                new FormControl('', Validators.required),
            streetAddress:
                new FormControl('', Validators.required),
            aptOrSuite:
                new FormControl('', Validators.required),
            state:
                new FormControl('', Validators.required),
            zipCode:
                new FormControl('', Validators.required),
        })
    }

    onSubmit() {
        if (this.form.valid) {
            // Do stuff, idk yet
        }
    }

    // Need to move to service class when time allows
    // #region API calls

    postQuote(newQuote: Quote) {
        var httpRequest = this.http.post<number>(`${this.apiUrl}/discounts`, newQuote)

        httpRequest.subscribe(
            success => {
                // Change "/discounts" to the correct URL of following page
                // this.router.navigateByUrl("/discounts")
            })
    }

    // #endRegion
}
