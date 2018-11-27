


export interface ICalculateResultComponent {
    data: any;
}

export interface ICalculateResult {
    type: string;
    result: number;
}

export class CalculateResultParity implements ICalculateResult {
    type: string;
    result: number;
    parity: string;
}

export class CalculateResultColor implements ICalculateResult {
    type: string;
    result: number;
    color: string;
}

export class CalculateResultNumber implements ICalculateResult {
    type: string;
    result: number;
}

export interface ICalculateOperationDto {
    resultType: string;
    operator: string;
    a: number;
    b: number;
}

export class CalculateOperationDto implements ICalculateOperationDto {
    resultType: string;
    operator: string;
    a: number;
    b: number;

    constructor(
        resultType: string,
        operator: string,
        a: number,
        b: number,) {
        this.resultType = resultType;
        this.operator = operator;
        this.a = a;
        this.b = b;
    }
}
