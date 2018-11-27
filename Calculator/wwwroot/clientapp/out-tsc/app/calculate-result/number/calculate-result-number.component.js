var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
var CalculateResultNumberComponent = /** @class */ (function () {
    function CalculateResultNumberComponent() {
    }
    CalculateResultNumberComponent.prototype.ngOnInit = function () { throw new Error("Not implemented"); };
    CalculateResultNumberComponent.prototype.ngOnDestroy = function () { throw new Error("Not implemented"); };
    CalculateResultNumberComponent.prototype.loadComponent = function () { throw new Error("Not implemented"); };
    CalculateResultNumberComponent.prototype.getAds = function () { throw new Error("Not implemented"); };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], CalculateResultNumberComponent.prototype, "data", void 0);
    CalculateResultNumberComponent = __decorate([
        Component({
            template: "\n    <div class=\"job-ad\">\n      <h4>{{data.headline}}</h4>\n\n      {{data.body}}\n    </div>\n  "
        })
    ], CalculateResultNumberComponent);
    return CalculateResultNumberComponent;
}());
export { CalculateResultNumberComponent };
//# sourceMappingURL=calculate-result-number.component.js.map