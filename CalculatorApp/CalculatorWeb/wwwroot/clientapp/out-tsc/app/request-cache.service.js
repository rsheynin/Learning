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
import { MessageService } from './message.service';
var RequestCache = /** @class */ (function () {
    function RequestCache() {
    }
    return RequestCache;
}());
export { RequestCache };
var maxAge = 30000; // maximum cache age (ms)
var RequestCacheWithMap = /** @class */ (function () {
    function RequestCacheWithMap(messenger) {
        this.messenger = messenger;
        this.cache = new Map();
    }
    RequestCacheWithMap.prototype.get = function (req) {
        var url = req.urlWithParams;
        var cached = this.cache.get(url);
        if (!cached) {
            return undefined;
        }
        var isExpired = cached.lastRead < (Date.now() - maxAge);
        var expired = isExpired ? 'expired ' : '';
        this.messenger.add("Found " + expired + "cached response for \"" + url + "\".");
        return isExpired ? undefined : cached.response;
    };
    RequestCacheWithMap.prototype.put = function (req, response) {
        var _this = this;
        var url = req.urlWithParams;
        this.messenger.add("Caching response from \"" + url + "\".");
        var entry = { url: url, response: response, lastRead: Date.now() };
        this.cache.set(url, entry);
        // remove expired cache entries
        var expired = Date.now() - maxAge;
        this.cache.forEach(function (entry) {
            if (entry.lastRead < expired) {
                _this.cache.delete(entry.url);
            }
        });
        this.messenger.add("Request cache size: " + this.cache.size + ".");
    };
    RequestCacheWithMap = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [MessageService])
    ], RequestCacheWithMap);
    return RequestCacheWithMap;
}());
export { RequestCacheWithMap };
/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=request-cache.service.js.map