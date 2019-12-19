import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from './_services';
import { User, Role } from './_models';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent {
    currentUser: User;

    constructor(
        private router: Router,
        private accountService: AccountService
    ) {
        this.accountService.currentUser.subscribe(x => this.currentUser = x);
    }

    get isManager() {
        return this.currentUser && this.currentUser.roles.includes(Role.Manager);
    }

    logout() {
        this.accountService.logout();
        this.router.navigate(['/login']);
    }
}