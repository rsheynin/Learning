var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from '@angular/core';
import { HttpResponse, HttpEventType } from '@angular/common/http';
import { Observable } from 'rxjs';
/** Simulate server replying to file upload request */
var UploadInterceptor = /** @class */ (function () {
    function UploadInterceptor() {
    }
    UploadInterceptor.prototype.intercept = function (req, next) {
        if (req.url.indexOf('/upload/file') === -1) {
            return next.handle(req);
        }
        var delay = 300; // TODO: inject delay?
        return createUploadEvents(delay);
    };
    UploadInterceptor = __decorate([
        Injectable()
    ], UploadInterceptor);
    return UploadInterceptor;
}());
export { UploadInterceptor };
/** Create simulation of upload event stream */
function createUploadEvents(delay) {
    // Simulate XHR behavior which would provide this information in a ProgressEvent
    var chunks = 5;
    var total = 12345678;
    var chunkSize = Math.ceil(total / chunks);
    return new Observable(function (observer) {
        // notify the event stream that the request was sent.
        observer.next({ type: HttpEventType.Sent });
        uploadLoop(0);
        function uploadLoop(loaded) {
            // N.B.: Cannot use setInterval or rxjs delay (which uses setInterval)
            // because e2e test won't complete. A zone thing?
            // Use setTimeout and tail recursion instead.
            setTimeout(function () {
                loaded += chunkSize;
                if (loaded >= total) {
                    var doneResponse = new HttpResponse({
                        status: 201,
                    });
                    observer.next(doneResponse);
                    observer.complete();
                    return;
                }
                var progressEvent = {
                    type: HttpEventType.UploadProgress,
                    loaded: loaded,
                    total: total
                };
                observer.next(progressEvent);
                uploadLoop(loaded);
            }, delay);
        }
    });
}
/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=upload-interceptor.js.map