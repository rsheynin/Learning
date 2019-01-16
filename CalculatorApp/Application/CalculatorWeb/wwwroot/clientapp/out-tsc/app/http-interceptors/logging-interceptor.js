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
import { HttpResponse } from '@angular/common/http';
import { finalize, tap } from 'rxjs/operators';
import { MessageService } from '../message.service';
var LoggingInterceptor = /** @class */ (function () {
    function LoggingInterceptor(messenger) {
        this.messenger = messenger;
    }
    LoggingInterceptor.prototype.intercept = function (req, next) {
        var _this = this;
        var started = Date.now();
        var ok;
        // extend server response observable with logging
        return next.handle(req)
            .pipe(tap(
        // Succeeds when there is a response; ignore other events
        function (event) { return ok = event instanceof HttpResponse ? 'succeeded' : ''; }, 
        // Operation failed; error is an HttpErrorResponse
        function (error) { return ok = 'failed'; }), 
        // Log when response observable either completes or errors
        finalize(function () {
            var elapsed = Date.now() - started;
            var msg = req.method + " \"" + req.urlWithParams + "\"\n             " + ok + " in " + elapsed + " ms.";
            _this.messenger.add(msg);
        }));
    };
    LoggingInterceptor = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [MessageService])
    ], LoggingInterceptor);
    return LoggingInterceptor;
}());
export { LoggingInterceptor };
/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=logging-interceptor.js.map