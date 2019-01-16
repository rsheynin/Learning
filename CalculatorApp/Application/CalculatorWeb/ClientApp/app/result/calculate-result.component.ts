import { Component, Input, OnInit, OnChanges, ViewChild, ComponentFactoryResolver, OnDestroy, Type } from '@angular/core';

import { CalculateResultDirective } from './calculate-result.directive';
import { ICalculateResult, ICalculateResultComponent } from '../models/calculate-result';

import { CalculateResultColorComponent } from './calculate-result-color.component';
import { CalculateResultNumberComponent } from './calculate-result-number.component';
import { CalculateResultParityComponent } from './calculate-result-parity.component';


@Component({
    selector: 'calculateresult',
    template: `<ng-template calculate-result-directive></ng-template>`
})
export class CalculateResultComponent implements OnInit, OnChanges {
    @Input() calculateResult: ICalculateResult;
    @ViewChild(CalculateResultDirective) calculateResultDirective: CalculateResultDirective;

    resultItems: any;


    constructor(private componentFactoryResolver: ComponentFactoryResolver) {
        
    }

    ngOnInit() {
        this.loadComponent();
    }

    ngOnChanges() {
        // changes.prop contains the old and the new value...
        this.loadComponent();
    }


    loadComponent() {
        this.resultItems = {
            "Color": new ResultItem(CalculateResultColorComponent, this.calculateResult),
            "Number": new ResultItem(CalculateResultNumberComponent, this.calculateResult),
            "Parity": new ResultItem(CalculateResultParityComponent, this.calculateResult), 
        };

        let resultItem = this.resultItems[this.calculateResult.type];

        let componentFactory = this.componentFactoryResolver.resolveComponentFactory(resultItem.component);

        let viewContainerRef = this.calculateResultDirective.viewContainerRef;
        viewContainerRef.clear();

        let componentRef = viewContainerRef.createComponent(componentFactory);
        (<ICalculateResultComponent>componentRef.instance).data = resultItem.data;
    }


}


export class ResultItem {
    constructor(public component: Type<any>, public data: any) { }
}
