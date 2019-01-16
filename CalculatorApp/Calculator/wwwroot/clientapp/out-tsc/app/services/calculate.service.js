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
import { Inject, Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
var CalculateResultService = /** @class */ (function () {
    function CalculateResultService(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    CalculateResultService.prototype.handleError = function (operation, result) {
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead
            // TODO: better job of transforming error for user consumption
            //this.log(`${operation} failed: ${error.message}`);
            // Let the app keep running by returning an empty result.
            return of(result);
        };
    };
    CalculateResultService.prototype.getOperators = function () {
        return this.http
            .get(this.baseUrl + 'api/Operator');
    };
    CalculateResultService.prototype.getResultTypes = function () {
        return this.http
            .get(this.baseUrl + 'api/CalculateResultType');
    };
    CalculateResultService.prototype.calculate = function (operationDto) {
        return this.http.post(this.baseUrl + 'api/Calculate', operationDto)
            .pipe(catchError(this.handleError('CalculateResult')));
    };
    CalculateResultService = __decorate([
        Injectable(),
        __param(1, Inject('BASE_URL')),
        __metadata("design:paramtypes", [HttpClient, String])
    ], CalculateResultService);
    return CalculateResultService;
}());
export { CalculateResultService };
//# sourceMappingURL=calculate.service.js.map