export interface ICurrencyRate {
    currId: number,
    currAbbr: string,
    valueToRub: number
}

export interface ICurrencyRateList {
    rates: ICurrencyRate[],
    dateUpdated: string
}

export interface ICurrencies {
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

export interface IConvertedCurrencies {
    currId: number,
    currAbbr: string,
    currValue: number
}