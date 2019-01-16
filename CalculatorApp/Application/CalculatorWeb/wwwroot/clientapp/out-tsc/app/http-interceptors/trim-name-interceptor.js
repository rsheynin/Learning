var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from '@angular/core';
var TrimNameInterceptor = /** @class */ (function () {
    function TrimNameInterceptor() {
    }
    TrimNameInterceptor.prototype.intercept = function (req, next) {
        var body = req.body;
        if (!body || !body.name) {
            return next.handle(req);
        }
        // copy the body and trim whitespace from the name property
        var newBody = __assign({}, body, { name: body.name.trim() });
        // clone request and set its body
        var newReq = req.clone({ body: newBody });
        // send the cloned request to the next handler.
        return next.handle(newReq);
    };
    TrimNameInterceptor = __decorate([
        Injectable()
    ], TrimNameInterceptor);
    return TrimNameInterceptor;
}());
export { TrimNameInterceptor };
/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=trim-name-interceptor.js.map