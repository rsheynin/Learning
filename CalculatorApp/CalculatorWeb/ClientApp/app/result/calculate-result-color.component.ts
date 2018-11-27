import { Component, Input } from '@angular/core';

import { ICalculateResultComponent } from '../models/calculate-result';

@Component({
    template: `
        <div [style.background-color]="data.color">{{data.result}}</div>
  `
})
export class CalculateResultColorComponent implements ICalculateResultComponent {
    @Input() data: any;
}

