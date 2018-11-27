var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { CalculateResultService } from './services/calculate.service';
import { CalculateResultDirective } from "./result/calculate-result.directive";
import { CalculateResultComponent } from "./result/calculate-result.component";
import { CalculateResultColorComponent } from "./result/calculate-result-color.component";
import { CalculateResultNumberComponent } from "./result/calculate-result-number.component";
import { CalculateResultParityComponent } from "./result/calculate-result-parity.component";
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [
                AppComponent,
                CalculateResultComponent,
                CalculateResultNumberComponent,
                CalculateResultColorComponent,
                CalculateResultParityComponent,
                CalculateResultDirective
            ],
            entryComponents: [
                CalculateResultNumberComponent,
                CalculateResultColorComponent,
                CalculateResultParityComponent
            ],
            imports: [
                BrowserModule,
                ReactiveFormsModule,
                HttpClientModule,
                FormsModule,
                HttpClientXsrfModule.withOptions({
                    cookieName: 'My-Xsrf-Cookie',
                    headerName: 'My-Xsrf-Header',
                })
            ],
            providers: [
                CalculateResultService
            ],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map