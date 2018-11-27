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
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var AppComponent = /** @class */ (function () {
    function AppComponent(http, baseUrl) {
        var _this = this;
        this.http = http;
        this.baseUrl = baseUrl;
        this.title = 'Welcome to Calculator Exercise';
        // http: HttpClient;
        this.operationDto = {
            a: undefined,
            b: undefined,
            operator: undefined,
            resultType: undefined,
        };
        http.get(baseUrl + 'api/Operator').subscribe(function (result) {
            _this.operators = result;
        }, function (error) { return console.error(error); });
        http.get(baseUrl + 'api/CalculateResultType').subscribe(function (result) {
            _this.resultTypes = result;
        }, function (error) { return console.error(error); });
    }
    AppComponent.prototype.ngOnInit = function () {
        //throw new Error("Not implemented");
    };
    AppComponent.prototype.calculate = function () {
        var _this = this;
        this.http.post(this.baseUrl + 'api/Calculate', this.operationDto).subscribe(function (result) {
            _this.calculateResult = result;
        }, function (error) {
            console.error(error);
        });
    };
    AppComponent = __decorate([
        Component({
            selector: 'app-root',
            templateUrl: './app.component.html',
            styleUrls: ['./app.component.css']
        }),
        __param(1, Inject('BASE_URL')),
        __metadata("design:paramtypes", [HttpClient, String])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
var CalculateResultParity = /** @class */ (function () {
    function CalculateResultParity() {
    }
    return CalculateResultParity;
}());
export { CalculateResultParity };
var CalculateResultColor = /** @class */ (function () {
    function CalculateResultColor() {
    }
    return CalculateResultColor;
}());
export { CalculateResultColor };
var CalculateResultNumber = /** @class */ (function () {
    function CalculateResultNumber() {
    }
    return CalculateResultNumber;
}());
export { CalculateResultNumber };
var CalculateOperationDto = /** @class */ (function () {
    function CalculateOperationDto() {
    }
    return CalculateOperationDto;
}());
export { CalculateOperationDto };
//# sourceMappingURL=calculate-result.component.parity.js.map