import axios, { AxiosError } from "axios";
import { insertByn, parseDate } from "./utils";

import { IResponseCurrencyRate, ICurrencyRateList, ICurrency, ICurrencyRate } from "../../shared/interfaces/currencyConverter.interface";
import { nbrbRatesAddress } from "../../shared/apiAdresses";
//"https://www.nbrb.by/api/exrates/rates?periodicity=0"

export async function GetCurrencyRates(
    requiredCurrencies: ICurrency[]
): Promise<ICurrencyRateList> {
    let result: ICurrencyRateList = {rates: [], dateUpdated: ""};
    result = insertByn(result);

    await axios.get<IResponseCurrencyRate[]>(nbrbRatesAddress)
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
            .catch((error: AxiosError) => {
                if (error.response) {
                    console.log("Error: request was made and response was recieved.");
                }
                else if (error.request) {
                    console.log("Error: request was made but no response was recieved.")
                }
                else {
                    console.log("Error: ", error.message);
                }
            })
    
    return result;
}
