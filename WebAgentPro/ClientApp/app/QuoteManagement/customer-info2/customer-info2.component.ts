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

    quote: Quote;

    form: FormGroup

    constructor(
        private route: ActivatedRoute,
        private http: HttpClient,
        private router: Router) { }

    ngOnInit(): void {
        this.route.queryParams.subscribe(params => {
            const quoteId = params['quoteId'];
            console.log(quoteId);
            if (quoteId) {
                //this.getQuote(quoteId)
                console.log(this.quote)
            }
        });

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

            if (this.router.url.endsWith('/quotes2')) {
                this.router.navigate(['/quotes3'])
            }
            
      
        
    }

    // Need to move to service class when time allows
    // #region API calls

    getQuote(quoteId: string) {
        var httpRequest = this.http.get<Quote>(`${this.apiUrl}/quotes/${quoteId}`)

        httpRequest.subscribe(returnedQuote => {
            this.quote = returnedQuote;
        })
    }
    // Will need to be a put request for the quote started in previous screen

    // #endRegion
}
