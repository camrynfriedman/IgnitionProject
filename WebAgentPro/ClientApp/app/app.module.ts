import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule }    from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent }  from './app.component';
import { routing }        from './app.routing';

import { NgxPaginationModule } from 'ngx-pagination'; 

import { JwtInterceptor, ErrorInterceptor } from './_security';
import { UsersComponent } from './usermanagement/users/users.component';
import { LoginComponent } from './registerlogin/login/login.component';
import { RegisterComponent } from './registerlogin/register/register.component';
import { DiscountsComponent } from './discountmanagement/discounts/discounts.component';
import { DiscountEditComponent } from './discountmanagement/discount-edit/discount-edit.component';
import { RoutenotfoundComponent } from './_security/routenotfound/routenotfound.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { CustomerInfo1Component } from './quotemanagement/customer-info1/customer-info1.component';
import { CustomerInfo2Component } from './QuoteManagement/customer-info2/customer-info2.component';
import { DriverInfoComponent } from './quotemanagement/driver-info/driver-info.component';
import { VehicleInfo1Component } from './quotemanagement/vehicle-info1/vehicle-info1.component';
import { VehicleInfo2Component } from './quotemanagement/vehicle-info2/vehicle-info2.component';
import { ContinueBtnComponent } from './components/buttons/continue-btn/continue-btn.component';
import { ReturnBtnComponent } from './components/buttons/return-btn/return-btn.component';
import { ProgressBarComponent } from './components/progress-bar/progress-bar.component';
import { FormErrorMessageComponent } from './components/form-error-message/form-error-message.component';
import { BackBtnComponent } from './components/buttons/back-btn/back-btn.component';
  
@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        NgxPaginationModule,
        routing
    ],
    declarations: [
        AppComponent,
        LoginComponent,
        UsersComponent,
        RegisterComponent,
        DiscountsComponent,
        DiscountEditComponent,
        RoutenotfoundComponent,
        HeaderComponent,
        FooterComponent,
        CustomerInfo1Component,
        CustomerInfo2Component,
        DriverInfoComponent,
        VehicleInfo1Component,
        VehicleInfo2Component,
        ContinueBtnComponent,
        ReturnBtnComponent,
        ProgressBarComponent,
        FormErrorMessageComponent,
        BackBtnComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
