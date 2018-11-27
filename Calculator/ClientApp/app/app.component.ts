import { Component, Inject, Input, OnInit, AfterViewInit, TemplateRef, ViewChild } from '@angular/core';
import { Observable, of } from 'rxjs';
import { CalculateResultService } from './services/calculate.service';
import { HttpClient } from '@angular/common/http';

import { CalculateOperationDto, ICalculateResult } from "./calculate-result/calculate-result"
 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, AfterViewInit {
    ngAfterViewInit(): void {
        //throw new Error("Method not implemented.");
    }
    

    private title = 'Welcome to Calculator Exercise';
    private operationDto: CalculateOperationDto = {
        a: undefined,
        b: undefined,
        operator : undefined,
        resultType : undefined,
    };
    private operators$: Observable<string[]>;
    private operatorsTest$: Observable<string[]>;
    private resultTypes$: Observable<string[]>;
    private calculateResult$: Observable<ICalculateResult>;
    private calculateTemplate: string;

    constructor(private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private calculateResultService: CalculateResultService) {

        this.operators$ = this.calculateResultService.getOperators();
        this.resultTypes$ = this.calculateResultService.getResultTypes();

        let operationDto = new CalculateOperationDto('Number', '+', 4, 5);
        //this.calculateResult$ = this.calculateResultService.calculate(operationDto);

        this.calculateResult$ = this.http
            .post<ICalculateResult>(
            this.baseUrl + 'api/Calculate',
                operationDto);
    }

    ngOnInit(): void {
         //throw new Error("Not implemented");
    }

    getOperators() {
        let operationDto =  new CalculateOperationDto('Number','+',4,5);
        this.calculateResult$ = this.calculateResultService.calculate(operationDto);
    }

    public calculate() {
        this.calculateResult$ = this.calculateResultService.calculate(this.operationDto);
    }

}
