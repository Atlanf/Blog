import axios from "axios";
import { insertByn, parseDate } from "./utils";

import { IResponseCurrencyRate, ICurrencyRateList, ICurrencies, ICurrencyRate } from "./types";

export async function GetCurrencyRates(
    url: string, 
    requiredCurrencies: ICurrencies[]
): Promise<ICurrencyRateList> {
    let result: ICurrencyRateList = {rates: [], dateUpdated: ""};
    result = insertByn(result);

    await axios.get<IResponseCurrencyRate[]>(url)
            .then(response => {
                let rates: IResponseCurrencyRate[] = [];
                rates = response.data.filter(o =>
                    requiredCurrencies.some(({currAbbr}) => o.Cur_Abbreviation === currAbbr)
                );
                rates.forEach((val) => {
                    let curr: ICurrencyRate = {
                        currId: val.Cur_ID,
                        currAbbr: val.Cur_Abbreviation,
                        valueToRub: Number((val.Cur_OfficialRate / val.Cur_Scale).toFixed(4))
                    };
                    result.rates.push(curr);
                })
                result.dateUpdated = parseDate(new Date());
            })
    
    return result;
}
