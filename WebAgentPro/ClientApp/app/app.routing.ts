import { Routes, RouterModule } from '@angular/router';

import { Roles, AuthGuard } from './_security';

import { RegisterComponent } from './registerlogin/register/register.component';
import { LoginComponent } from './registerlogin/login/login.component';
import { UsersComponent } from './usermanagement/users/users.component';
import { DiscountsComponent } from './discountmanagement/discounts/discounts.component';
import { DiscountEditComponent } from './discountmanagement/discount-edit/discount-edit.component';
import { CustomerInfo1Component } from './quotemanagement/customer-info1/customer-info1.component';
import { CustomerInfo2Component } from './quotemanagement/customer-info2/customer-info2.component';
import { DriverInfoComponent } from './quotemanagement/driver-info/driver-info.component';
import { VehicleInfo1Component } from './quotemanagement/vehicle-info1/vehicle-info1.component';
import { VehicleInfo2Component } from './quotemanagement/vehicle-info2/vehicle-info2.component';
import { AgentDashboardComponent } from './agent-dashboard/agent-dashboard.component';

import { RoutenotfoundComponent } from './_security/routenotfound/routenotfound.component';

const appRoutes: Routes = [
    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'users', component: UsersComponent, canActivate: [AuthGuard], data: { roles: [Roles.Manager] } },
    { path: 'discounts', component: DiscountsComponent, canActivate: [AuthGuard], data: { roles: [Roles.Manager] } },
    { path: 'quotes1', component: CustomerInfo1Component },
    { path: 'quotes2', component: CustomerInfo2Component },
    { path: 'quotes3', component: DriverInfoComponent },
    { path: 'quotes4', component: VehicleInfo1Component },
    { path: 'quotes5', component: VehicleInfo2Component },
    { path: 'agentDashboard', component: AgentDashboardComponent },

    // parameterized route so you can tell the component what action you want to take on which state's discounts
    { path: 'discount/:action/:state', component: DiscountEditComponent, canActivate: [AuthGuard], data: { roles: [Roles.Manager] } },

    // default route when nothing specified
    { path: '', component: DiscountsComponent, canActivate: [AuthGuard] },

    // any other route will redirect here
    { path: '**', component: RoutenotfoundComponent, canActivate: [AuthGuard] }
];

export const routing = RouterModule.forRoot(appRoutes, { relativeLinkResolution: 'legacy' });
