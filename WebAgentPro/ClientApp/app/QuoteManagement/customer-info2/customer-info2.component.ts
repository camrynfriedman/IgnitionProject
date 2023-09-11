import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from '@environments/environment';

import { Quote } from '@app/_models/quote';

@Component({
  templateUrl: './customer-info2.component.html',
  styleUrls: ['./customer-info2.component.css']
})
export class CustomerInfo2Component implements OnInit {

    apiUrl: string = environment.apiUrl

    // This will need to be a quote object passed from previous screen
    quote: Quote;

    form: FormGroup

    constructor(
        private route: ActivatedRoute,
        private http: HttpClient,
        private router: Router) { }

    ngOnInit(): void {
        this.form = new FormGroup({
            previousCarrierL:
                new FormControl('', Validators.required),
            previousCarrierP:
                new FormControl('', Validators.required),
            recentMovingViolations:
                new FormControl('', Validators.required),
            recentClaims:
                new FormControl('', Validators.required),
            multipleCars:
                new FormControl('', Validators.required),
            lowDrivingExperience:
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

    // Will need to be a put request for the quote started in previous screen

    // #endRegion
}
