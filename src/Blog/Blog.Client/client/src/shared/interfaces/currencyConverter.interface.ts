export interface ICurrencyRate {
    currId: number,
    currAbbr: string,
    valueToRub: number
}

export interface ICurrencyRateList {
    rates: ICurrencyRate[],
    dateUpdated: string,
    error: boolean
}

export interface ICurrency {
    currId: number;
    currAbbr: string;
}

export interface IResponseCurrencyRate {
    Cur_Abbreviation: string,
    Cur_ID: number,
    Cur_Name: string,
    Cur_OfficialRate: number,
    Cur_Scale: number,
    Date: Date
}

export interface IConvertedCurrency {
    currId: number,
    currAbbr: string,
    currValue: string
}
