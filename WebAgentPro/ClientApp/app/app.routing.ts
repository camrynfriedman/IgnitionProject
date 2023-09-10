import { Routes, RouterModule } from '@angular/router';

import { Roles, AuthGuard } from './_security';

import { RegisterComponent } from './registerlogin/register/register.component';
import { LoginComponent } from './registerlogin/login/login.component';
import { UsersComponent } from './usermanagement/users/users.component';
import { DiscountsComponent } from './discountmanagement/discounts/discounts.component';
import { DiscountEditComponent } from './discountmanagement/discount-edit/discount-edit.component';
import { CustomerInfo1Component } from './quotemanagement/customer-info1/customer-info1.component';
import { CustomerInfo2Component } from './quotemanagement/customer-info2/customer-info2.component';

/* Related to routing for the following tasks:
 * 9273
import { DriverInfoComponent } from './quotemanagement/driver-info/driver-info.component';
 * 9274
import { VehicleInfo1Component } from './quotemanagement/vehicle-info1/vehicle-info1.component';
 * 9275
import { VehicleInfo2Component } from './quotemanagement/vehicle-info2/vehicle-info2.component';
*/
import { RoutenotfoundComponent } from './_security/routenotfound/routenotfound.component';

const appRoutes: Routes = [
    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'users', component: UsersComponent, canActivate: [AuthGuard], data: { roles: [Roles.Manager] } },
    { path: 'discounts', component: DiscountsComponent, canActivate: [AuthGuard], data: { roles: [Roles.Manager] } },
    { path: 'quotes', component: CustomerInfo1Component },
    { path: 'quotes2', component: CustomerInfo2Component },

    // parameterized route so you can tell the component what action you want to take on which state's discounts
    { path: 'discount/:action/:state', component: DiscountEditComponent, canActivate: [AuthGuard], data: { roles: [Roles.Manager] } },

    // default route when nothing specified
    { path: '', component: DiscountsComponent, canActivate: [AuthGuard] },

    // any other route will redirect here
    { path: '**', component: RoutenotfoundComponent, canActivate: [AuthGuard] }
];

export const routing = RouterModule.forRoot(appRoutes, { relativeLinkResolution: 'legacy' });
