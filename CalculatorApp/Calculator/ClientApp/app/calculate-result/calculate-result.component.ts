import { Component, Input, OnInit, ViewChild, ComponentFactoryResolver, OnDestroy } from '@angular/core';

import { CalculateResultDirective } from './calculate-result.directive';
import { ICalculateResult } from './calculate-result';
//import { AdItem } from './ad-item';
//import { AdComponent } from './ad.component';


@Component({
    selector: 'calculate-result',
    template: `<ng-template calculate-result-directive></ng-template>`
})
export class CalculateResultComponent implements OnInit {
    @Input() calculateResult: ICalculateResult;
    @ViewChild(CalculateResultDirective) calculateResultDirective: CalculateResultDirective;

    constructor(private componentFactoryResolver: ComponentFactoryResolver) { }

    ngOnInit() {
        this.loadComponent();
    }
    

    loadComponent() {
        //this.currentAdIndex = (this.currentAdIndex + 1) % this.ads.length;
        //let adItem = this.ads[this.currentAdIndex];

        //let componentFactory = this.componentFactoryResolver.resolveComponentFactory(adItem.component);

        //let viewContainerRef = this.adHost.viewContainerRef;
        //viewContainerRef.clear();

        //let componentRef = viewContainerRef.createComponent(componentFactory);
        //(<AdComponent>componentRef.instance).data = adItem.data;
    }
}
