import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
    selector: '[calculate-result-directive]'
})
export class CalculateResultDirective {
    constructor(public viewContainerRef: ViewContainerRef) {}
}
