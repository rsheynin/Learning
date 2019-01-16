import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
    selector: '[calculate-result]'
})
export class CalculateResultDirective {
    constructor(public viewContainerRef: ViewContainerRef) {}
}
