import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from '@environments/environment';

import { Quote } from '@app/_models/quote';

@Component({
    templateUrl: './customer-info1.component.html',
    styleUrls: ['./customer-info1.component.css']
})
export class CustomerInfo1Component implements OnInit {

    apiUrl: string = environment.apiUrl;
    allStates: string[];

    // This object will need to be passed to the next page
    // (probably the quote ID, then call getQuote)
    action: string;
    quote: Quote;

    form: FormGroup;

    constructor(
        private route: ActivatedRoute,
        private http: HttpClient,
        private router: Router) { }

    ngOnInit(): void {
        this.getAllStates()

        this.form = new FormGroup({
            policyHolderFName:
                new FormControl('', Validators.required),
            policyHolderLName:
                new FormControl('', Validators.required),
            policyHolderDOB:
                new FormControl('', Validators.required),
            addressLine1:
                new FormControl('', Validators.required),
            addressLine2:
                new FormControl(),
            city:
                new FormControl('', Validators.required),
            state:
                new FormControl('', Validators.required),
            postalCode:
                new FormControl('', Validators.compose([
                    Validators.required,
                    Validators.pattern(/^\d{5}$/)])),
            policyHolderEmailAddress:
                new FormControl('', Validators.required),
            policyHolderPhoneNumber:
                new FormControl('', Validators.required)
        })
    }

    onSubmit() {
        console.log("onSubmit triggered")
        if (this.form.valid) {
            this.bindQuote(this.form)
            this.postQuote(this.quote)
            /*
            switch (this.action) {
                case "add":
                    this.postQuote(this.form.value)
                    break;
                case "edit":
                    this.postQuote(this.form.value)
                    break;
            }
             */
        }
    }

    bindQuote(form: FormGroup) {
        this.quote = new Quote(form.value);
    }

    // Need to move to service class when time allows
    // #region API calls

    getAllStates() {
        var httpRequest = this.http.get<string[]>(`${this.apiUrl}/discounts/allstates`)

        httpRequest.subscribe(returnedStates => {
            this.allStates = returnedStates
        })
    }

    postQuote(newQuote: Quote) {
        console.log("postQuote triggered")
        var httpRequest = this.http.post<Quote>(`${this.apiUrl}/quotes`, newQuote);

        httpRequest.subscribe(
            success => {
                this.router.navigate(['/quotes2'], { queryParams: { quoteId: success.quoteId } });
            }
        );
    }

    // #endRegion
}
