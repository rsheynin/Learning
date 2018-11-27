var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
var ConfigService = /** @class */ (function () {
    function ConfigService(http) {
        this.http = http;
        this.configUrl = 'assets/config.json';
    }
    ConfigService.prototype.getConfig = function () {
        return this.http.get(this.configUrl)
            .pipe(retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
        );
    };
    ConfigService.prototype.getConfig_1 = function () {
        return this.http.get(this.configUrl);
    };
    ConfigService.prototype.getConfig_2 = function () {
        // now returns an Observable of Config
        return this.http.get(this.configUrl);
    };
    ConfigService.prototype.getConfig_3 = function () {
        return this.http.get(this.configUrl)
            .pipe(catchError(this.handleError));
    };
    ConfigService.prototype.getConfigResponse = function () {
        return this.http.get(this.configUrl, { observe: 'response' });
    };
    ConfigService.prototype.handleError = function (error) {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error("Backend returned code " + error.status + ", " +
                ("body was: " + error.error));
        }
        // return an observable with a user-facing error message
        return throwError('Something bad happened; please try again later.');
    };
    ;
    ConfigService.prototype.makeIntentionalError = function () {
        return this.http.get('not/a/real/url')
            .pipe(catchError(this.handleError));
    };
    ConfigService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], ConfigService);
    return ConfigService;
}());
export { ConfigService };
/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=config.service.js.map