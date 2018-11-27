import { Component, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';


import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

import { CalculateOperationDto, ICalculateResult, CalculateResultNumber,CalculateResultColor,CalculateResultParity } from "./models/calculate-result"
import { CalculateResultService } from './services/calculate.service';
import { CalculateResultDirective } from './result/calculate-result.directive';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'my-auth-token'
    })
};

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    private title = 'Welcome to Calculator Exercise';
    private operationDto: CalculateOperationDto = {
        a: undefined,
        b: undefined,
        operator: undefined,
        resultType: undefined,
    };
    private operators$: Observable<string[]>;
    private operatorsTest$: Observable<string[]>;
    private resultTypes$: Observable<string[]>;
    private calculateResult$: Observable<ICalculateResult>;
    private calculateResult: ICalculateResult;
    private calculateTemplate: string;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private calculateResultService: CalculateResultService) {

        this.operators$ = this.calculateResultService.getOperators();
        this.resultTypes$ = this.calculateResultService.getResultTypes();
    }

    calculate(/*operationDto: CalculateOperationDto*/) {
        //let operationDto = new CalculateOperationDto('Number', '+', 4, 5);
        this.http.post<ICalculateResult>(this.baseUrl + 'api/Calculate', this.operationDto).subscribe(x => {
            this.calculateResult = x;
        });
    }
}
