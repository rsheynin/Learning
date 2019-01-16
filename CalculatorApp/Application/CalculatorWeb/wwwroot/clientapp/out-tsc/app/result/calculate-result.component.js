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
import { CalculateResultColorComponent } from './calculate-result-color.component';
import { CalculateResultNumberComponent } from './calculate-result-number.component';
import { CalculateResultParityComponent } from './calculate-result-parity.component';
var CalculateResultComponent = /** @class */ (function () {
    function CalculateResultComponent(componentFactoryResolver) {
        this.componentFactoryResolver = componentFactoryResolver;
    }
    CalculateResultComponent.prototype.ngOnInit = function () {
        this.loadComponent();
    };
    CalculateResultComponent.prototype.ngOnChanges = function () {
        // changes.prop contains the old and the new value...
        this.loadComponent();
    };
    CalculateResultComponent.prototype.loadComponent = function () {
        this.resultItems = {
            "Color": new ResultItem(CalculateResultColorComponent, this.calculateResult),
            "Number": new ResultItem(CalculateResultNumberComponent, this.calculateResult),
            "Parity": new ResultItem(CalculateResultParityComponent, this.calculateResult),
        };
        var resultItem = this.resultItems[this.calculateResult.type];
        var componentFactory = this.componentFactoryResolver.resolveComponentFactory(resultItem.component);
        var viewContainerRef = this.calculateResultDirective.viewContainerRef;
        viewContainerRef.clear();
        var componentRef = viewContainerRef.createComponent(componentFactory);
        componentRef.instance.data = resultItem.data;
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
            selector: 'calculateresult',
            template: "<ng-template calculate-result-directive></ng-template>"
        }),
        __metadata("design:paramtypes", [ComponentFactoryResolver])
    ], CalculateResultComponent);
    return CalculateResultComponent;
}());
export { CalculateResultComponent };
var ResultItem = /** @class */ (function () {
    function ResultItem(component, data) {
        this.component = component;
        this.data = data;
    }
    return ResultItem;
}());
export { ResultItem };
//# sourceMappingURL=calculate-result.component.js.map