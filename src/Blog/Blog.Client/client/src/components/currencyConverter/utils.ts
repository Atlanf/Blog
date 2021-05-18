import { getCurrencyRates } from "./api";
import { IConvertedCurrency, ICurrency, ICurrencyRateList } from "../../shared/interfaces/currencyConverter.interface";

export async function loadCurrencyRates(
    requiredCurrencies: ICurrency[],
    localStorageRatesKey: string
): Promise<ICurrencyRateList> {
    var localStorageValue: string | null = localStorage.getItem(localStorageRatesKey);
    var rates: ICurrencyRateList = {} as ICurrencyRateList;

    if (localStorageValue != null) {
        rates = JSON.parse(localStorageValue);
        if (rates.dateUpdated !== parseDate(new Date())) {
            let rates: ICurrencyRateList = await getCurrencyRates(requiredCurrencies);
            if (!rates.error) {
                let currencies: string = JSON.stringify(rates);
                localStorage.removeItem(localStorageRatesKey);
                localStorage.setItem(localStorageRatesKey, currencies);
            }
        }
    }
    else {
        let currencies: string = JSON.stringify(await getCurrencyRates(requiredCurrencies)); 
        localStorage.setItem(localStorageRatesKey, currencies);
    }

    return JSON.parse(localStorage.getItem(localStorageRatesKey)!);
}

export function convertCurrencies(
    rateList: ICurrencyRateList,
    value: string,
    basisCurrency: string
): IConvertedCurrency[] {
    let result : IConvertedCurrency[] = [];
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
                currValue: ((Number(value) * rate / val.valueToRub).toFixed(4)).toString() 
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

export function inputIsValid(input: string): boolean {
    if (input.match(/[^0-9.]/)) {
        return false;
    }
    
    if (input.startsWith(".")) {
        return false;
    }

    let entries = input.match(/\./g);
    if (entries != null && entries.length > 1) {
        return false;
    }

    return true;
}