import { Component, Input } from '@angular/core';

import { ICalculateResultComponent } from './calculate-result';

@Component({
    template: `
        <div>{{data.result}}</div> 
        <p></p>
        <div>{{data.parity}}</div> 
  `
})
export class CalculateResultNumberComponent implements ICalculateResultComponent {
    @Input() data: any;
}

