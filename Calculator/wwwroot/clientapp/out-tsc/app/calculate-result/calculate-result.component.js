var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, ViewChild, ComponentFactoryResolver } from '@angular/core';
import { CalculateResultDirective } from './calculate-result.directive';
//import { AdItem } from './ad-item';
//import { AdComponent } from './ad.component';
var CalculateResultComponent = /** @class */ (function () {
    function CalculateResultComponent(componentFactoryResolver) {
        this.componentFactoryResolver = componentFactoryResolver;
    }
    CalculateResultComponent.prototype.ngOnInit = function () {
        this.loadComponent();
    };
    CalculateResultComponent.prototype.loadComponent = function () {
        //this.currentAdIndex = (this.currentAdIndex + 1) % this.ads.length;
        //let adItem = this.ads[this.currentAdIndex];
        //let componentFactory = this.componentFactoryResolver.resolveComponentFactory(adItem.component);
        //let viewContainerRef = this.adHost.viewContainerRef;
        //viewContainerRef.clear();
        //let componentRef = viewContainerRef.createComponent(componentFactory);
        //(<AdComponent>componentRef.instance).data = adItem.data;
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], CalculateResultComponent.prototype, "calculateResult", void 0);
    __decorate([
        ViewChild(CalculateResultDirective),
        __metadata("design:type", CalculateResultDirective)
    ], CalculateResultComponent.prototype, "calculateResultDirective", void 0);
    CalculateResultComponent = __decorate([
        Component({
            selector: 'calculate-result',
            template: "<ng-template calculate-result-directive></ng-template>"
        }),
        __metadata("design:paramtypes", [ComponentFactoryResolver])
    ], CalculateResultComponent);
    return CalculateResultComponent;
}());
export { CalculateResultComponent };
//# sourceMappingURL=calculate-result.component.js.map