export interface ICalculateResultComponent {
    data: any;
}

export interface ICalculateResult {
    resultType: string;
    result: number;
}

export class CalculateResultParity implements ICalculateResult {
    resultType: string;
    result: number;
    parity: string;
}

export class CalculateResultColor implements ICalculateResult {
    resultType: string;
    result: number;
    color: string;
}

export class CalculateResultNumber implements ICalculateResult {
    resultType: string;
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
