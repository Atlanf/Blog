import { GetCurrencyRates as getCurrencyRates } from "./api";
import { IConvertedCurrencies, ICurrencies, ICurrencyRateList } from "./types";

export async function loadCurrencyRates(
    requiredCurrencies: ICurrencies[],
    requestUrl: string,
    localStorageRatesKey: string
): Promise<ICurrencyRateList> {
    var localStorageValue: string | null = localStorage.getItem(localStorageRatesKey);
    var rates: ICurrencyRateList = {} as ICurrencyRateList;

    if (localStorageValue != null) {
        rates = JSON.parse(localStorageValue);
        if (rates.dateUpdated !== parseDate(new Date())) {
            localStorage.removeItem(localStorageRatesKey);
            let currencies: string = JSON.stringify(await getCurrencyRates(requestUrl, requiredCurrencies));
            localStorage.setItem(localStorageRatesKey, currencies);
        }
    }
    else {
        let currencies: string = JSON.stringify(await getCurrencyRates(requestUrl, requiredCurrencies)); 
        localStorage.setItem(localStorageRatesKey, currencies);
    }

    return JSON.parse(localStorage.getItem(localStorageRatesKey)!);
}

export function convertCurrencies(
    rateList: ICurrencyRateList,
    value: number,
    basisCurrency: string
): IConvertedCurrencies[] {
    let result : IConvertedCurrencies[] = [];
    let rate = rateList.rates.filter((val) => {
        return val.currAbbr === basisCurrency
    })[0].valueToRub;
    
    rateList.rates.forEach((val) => {
        if (val.currAbbr === basisCurrency) {
            result.push({
                currId: val.currId,
                currAbbr: val.currAbbr,
                currValue: value
            });
        }
        else {
            result.push({
                currId: val.currId,
                currAbbr: val.currAbbr,
                currValue: Number((value * rate / val.valueToRub).toFixed(4)) 
            });
        }
    });

    return result;
}

export function parseDate(currentDate: Date): string {
    let result: string = currentDate.getDate() + "/" +
        (currentDate.getMonth() + 1) + "/" + currentDate.getFullYear();
    
    return result;
}

export function insertByn(rates: ICurrencyRateList): ICurrencyRateList {
    rates.rates.push({
        currId: 0,
        currAbbr: "BYN",
        valueToRub: 1
    });

    return rates; 
}