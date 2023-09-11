import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from '@environments/environment';

import { Quote } from '@app/_models/quote';
import { Driver } from '@app/_models/driver';

@Component({
  templateUrl: './vehicle-info1.component.html',
  styleUrls: ['./vehicle-info1.component.css']
})
export class VehicleInfo1Component implements OnInit {

    apiUrl: string = environment.apiUrl

    // This object will need to be passed to the next page
    // (probably the quote ID, then call getQuote)
    quote: Quote;

    form: FormGroup
    stepValue: number = 1;

    constructor(private route: ActivatedRoute, private http: HttpClient, private router: Router) { }

    ngOnInit(): void {
        this.form = new FormGroup({
            primaryDriver:
                new FormControl('', Validators.required),
            make:
                new FormControl('', Validators.required),
            model:
                new FormControl('', Validators.required),
            year:
                new FormControl('', Validators.required),
            vinNumber:
                new FormControl('', Validators.required),
            currentValue:
                new FormControl('', Validators.required),
            annualMileage:
                new FormControl('', Validators.required),
            daysPerWeek:
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
