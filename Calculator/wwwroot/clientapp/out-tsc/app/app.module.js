var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CalculateResultService } from './services/calculate.service';
import { CalculateResultComponent } from './calculate-result/calculate-result.component';
//import { CalculateResultNumberComponent } from './calculate-result/number/calculate-result-number.component';
//import { CalculateResultColorComponent } from './calculate-result/color/calculate-result-color.component';
//import { CalculateResultParityComponent } from './calculate-result/parity/calculate-result-parity.component';
import { CalculateResultDirective } from './calculate-result/calculate-result.directive';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [
                AppComponent,
                CalculateResultComponent,
                //CalculateResultNumberComponent,
                //CalculateResultColorComponent,
                //CalculateResultParityComponent,
                CalculateResultDirective
            ],
            imports: [
                BrowserModule,
                HttpClientModule,
                FormsModule
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