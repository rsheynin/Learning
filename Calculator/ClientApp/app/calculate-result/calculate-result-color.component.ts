import { Component, Input } from '@angular/core';

import { ICalculateResultComponent } from './calculate-result';

@Component({
    template: `
        <div [style.background-color]="data.color">{{data.result}}</div>
  `
})
export class CalculateResultNumberComponent implements ICalculateResultComponent {
    @Input() data: any;
}

