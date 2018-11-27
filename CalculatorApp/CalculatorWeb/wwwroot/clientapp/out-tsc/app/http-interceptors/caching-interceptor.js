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
import { HttpHeaders, HttpResponse } from '@angular/common/http';
import { of } from 'rxjs';
import { startWith, tap } from 'rxjs/operators';
import { RequestCache } from '../request-cache.service';
//import { searchUrl } from '../package-search/package-search.service';
/**
 * If request is cachable (e.g., package search) and
 * response is in cache return the cached response as observable.
 * If has 'x-refresh' header that is true,
 * then also re-run the package search, using response from next(),
 * returning an observable that emits the cached response first.
 *
 * If not in cache or not cachable,
 * pass request through to next()
 */
var CachingInterceptor = /** @class */ (function () {
    function CachingInterceptor(cache) {
        this.cache = cache;
    }
    CachingInterceptor.prototype.intercept = function (req, next) {
        // continue if not cachable.
        if (!isCachable(req)) {
            return next.handle(req);
        }
        var cachedResponse = this.cache.get(req);
        // cache-then-refresh
        if (req.headers.get('x-refresh')) {
            var results$ = sendRequest(req, next, this.cache);
            return cachedResponse ?
                results$.pipe(startWith(cachedResponse)) :
                results$;
        }
        // cache-or-fetch
        return cachedResponse ?
            of(cachedResponse) : sendRequest(req, next, this.cache);
    };
    CachingInterceptor = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [RequestCache])
    ], CachingInterceptor);
    return CachingInterceptor;
}());
export { CachingInterceptor };
/** Is this request cachable? */
function isCachable(req) {
    // Only GET requests are cachable
    return req.method === 'GET'; // &&
    // Only npm package search is cachable in this app
    //-1 < req.url.indexOf(searchUrl);
}
/**
 * Get server response observable by sending request to `next()`.
 * Will add the response to the cache on the way out.
 */
function sendRequest(req, next, cache) {
    // No headers allowed in npm search request
    var noHeaderReq = req.clone({ headers: new HttpHeaders() });
    return next.handle(noHeaderReq).pipe(tap(function (event) {
        // There may be other events besides the response.
        if (event instanceof HttpResponse) {
            cache.put(req, event); // Update the cache.
        }
    }));
}
/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=caching-interceptor.js.map