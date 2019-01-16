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
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { ConfigService } from './config.service';
var ConfigComponent = /** @class */ (function () {
    function ConfigComponent(configService) {
        this.configService = configService;
    }
    ConfigComponent.prototype.clear = function () {
        this.config = undefined;
        this.error = undefined;
        this.headers = undefined;
    };
    ConfigComponent.prototype.showConfig = function () {
        var _this = this;
        this.configService.getConfig()
            .subscribe(function (data) { return _this.config = __assign({}, data); }, // success path
        function (// success path
        error) { return _this.error = error; } // error path
        );
    };
    ConfigComponent.prototype.showConfig_v1 = function () {
        var _this = this;
        this.configService.getConfig_1()
            .subscribe(function (data) { return _this.config = {
            heroesUrl: data['heroesUrl'],
            textfile: data['textfile']
        }; });
    };
    ConfigComponent.prototype.showConfig_v2 = function () {
        var _this = this;
        this.configService.getConfig()
            // clone the data object, using its known Config shape
            .subscribe(function (data) { return _this.config = __assign({}, data); });
    };
    ConfigComponent.prototype.showConfigResponse = function () {
        var _this = this;
        this.configService.getConfigResponse()
            // resp is of type `HttpResponse<Config>`
            .subscribe(function (resp) {
            // display its headers
            var keys = resp.headers.keys();
            _this.headers = keys.map(function (key) {
                return key + ": " + resp.headers.get(key);
            });
            // access the body directly, which is typed as `Config`.
            _this.config = __assign({}, resp.body);
        });
    };
    ConfigComponent.prototype.makeError = function () {
        var _this = this;
        this.configService.makeIntentionalError().subscribe(null, function (error) { return _this.error = error; });
    };
    ConfigComponent = __decorate([
        Component({
            selector: 'app-config',
            templateUrl: './config.component.html',
            providers: [ConfigService],
            styles: ['.error {color: red;}']
        }),
        __metadata("design:paramtypes", [ConfigService])
    ], ConfigComponent);
    return ConfigComponent;
}());
export { ConfigComponent };
/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=config.component.js.map