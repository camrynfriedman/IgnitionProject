import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService, User, Roles } from '../../_security';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
    currentUser: User;

    constructor(
        private router: Router,
        private accountService: AccountService
    ) {
        this.accountService.currentUser.subscribe(x => this.currentUser = x);
    }

    get isManager() {
       
        return this.currentUser && this.currentUser.roles.includes(Roles.Manager);
    }

    logout() {
        this.accountService.logout();
        this.router.navigate(['/login']);
    }
}
