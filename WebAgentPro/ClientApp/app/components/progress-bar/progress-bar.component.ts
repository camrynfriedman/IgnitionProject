import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.css']
})
export class ProgressBarComponent {
    currentStep: string = 'Stepper_1';

    constructor(private router: Router) {
        this.router.events.subscribe(event => {
            if (event instanceof NavigationEnd) {
                console.log(event.urlAfterRedirects);
                this.updateStep(event.urlAfterRedirects);
            }
        })
    }

    updateStep(url: string) {
        switch (true) {
            case url.includes('quotes1'):
                console.log("QUOTES1 has been triggered!")
                this.currentStep = 'Stepper_1';
                break;
            case url.includes('quotes2'):
                console.log("QUOTES2 has been triggered!")
                this.currentStep = 'Stepper_2';
                break;
            case url.includes('quotes3'):
                console.log("QUOTES3 has been triggered!")
                this.currentStep = 'Stepper_3';
                break;
            case url.includes('quotes4'):
                console.log("QUOTES4 has been triggered!")
                this.currentStep = 'Stepper_4';
                break;
            case url.includes('quotes5'):
                console.log("QUOTES5 has been triggered!")
                this.currentStep = 'Stepper_5';
                break;
            default:
                console.log("Default has been triggered!")
                this.currentStep = 'Stepper_1';
                break;
        }
    }
}
