import { Component, Input } from '@angular/core';

import { ICalculateResultComponent } from '../models/calculate-result';

@Component({
    template: `
        <div>{{data.result}}</div> 
        <p></p>
        <div>{{data.parity}}</div> 
  `
})
export class CalculateResultParityComponent implements ICalculateResultComponent {
    @Input() data: any;
}

