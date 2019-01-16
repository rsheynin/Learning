import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

import { CalculateOperationDto, ICalculateResult } from "../calculate-result/calculate-result"


@Injectable()
export class CalculateResultService {
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead

            // TODO: better job of transforming error for user consumption
            //this.log(`${operation} failed: ${error.message}`);

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }

    constructor(private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) {}

    getOperators(): Observable<string[]> {
            return this.http
                .get<string[]>(this.baseUrl + 'api/Operator');
        
    }

    getResultTypes(): Observable<string[]> {
        return this.http
            .get<string[]>(this.baseUrl + 'api/CalculateResultType');
    }

    calculate(operationDto: CalculateOperationDto): Observable<ICalculateResult> {
        return this.http.post<ICalculateResult>(this.baseUrl + 'api/Calculate',operationDto)
            .pipe(
            catchError(this.handleError<ICalculateResult>('CalculateResult'))
            );
    }
}
