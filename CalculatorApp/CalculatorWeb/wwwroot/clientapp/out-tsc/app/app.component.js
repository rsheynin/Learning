var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Component } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CalculateResultService } from './services/calculate.service';
var httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'my-auth-token'
    })
};
var AppComponent = /** @class */ (function () {
    function AppComponent(http, baseUrl, calculateResultService) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.calculateResultService = calculateResultService;
        this.title = 'Welcome to Calculator Exercise';
        this.operationDto = {
            a: undefined,
            b: undefined,
            operator: undefined,
            resultType: undefined,
        };
        this.operators$ = this.calculateResultService.getOperators();
        this.resultTypes$ = this.calculateResultService.getResultTypes();
    }
    AppComponent.prototype.calculate = function ( /*operationDto: CalculateOperationDto*/) {
        var _this = this;
        //let operationDto = new CalculateOperationDto('Number', '+', 4, 5);
        this.http.post(this.baseUrl + 'api/Calculate', this.operationDto).subscribe(function (x) {
            _this.calculateResult = x;
        });
    };
    AppComponent = __decorate([
        Component({
            selector: 'app-root',
            templateUrl: './app.component.html',
            styleUrls: ['./app.component.css']
        }),
        __param(1, Inject('BASE_URL')),
        __metadata("design:paramtypes", [HttpClient, String, CalculateResultService])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.component.js.map