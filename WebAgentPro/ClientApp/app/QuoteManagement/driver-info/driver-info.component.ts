import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from '@environments/environment';

import { Quote } from '@app/_models/quote';

@Component({
  templateUrl: './driver-info.component.html',
  styleUrls: ['./driver-info.component.css']
})
export class DriverInfoComponent implements OnInit {

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
            firstName:
                new FormControl('', Validators.required),
            lastName:
                new FormControl('', Validators.required),
            dob:
                new FormControl('', Validators.required),
            ssn:
                new FormControl('', Validators.required),
            driverLicenseNumber:
                new FormControl('', Validators.required),
            driverLicenseState:
                new FormControl('', Validators.required),
            youngDriver:
                new FormControl('', Validators.required),
            safeDrivingSchool:
                new FormControl('', Validators.required),
        })
    }

    onSubmit() {
        if (this.router.url.endsWith('/quotes3')) {
                this.router.navigate(['/quotes4'])
            }

        
    }

    // Need to move to service class when time allows
    // #region API calls

    // Will need to be a put request for the quote started in previous screen

    // #endRegion
}
