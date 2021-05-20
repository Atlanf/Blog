import axios, { AxiosError } from "axios";
import { insertByn, parseDate } from "./utils";
import parseAxiosError from "../../utils/errorParser";

import { IResponseCurrencyRate, ICurrencyRateList, ICurrency, ICurrencyRate } from "../../shared/interfaces/";
import { nbrbRatesAddress } from "../../shared/apiAddresses";
//"https://www.nbrb.by/api/exrates/rates?periodicity=0"

export async function getCurrencyRates(
    requiredCurrencies: ICurrency[]
): Promise<ICurrencyRateList> {
    let result: ICurrencyRateList = {rates: [], dateUpdated: "", error: false};
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
                parseAxiosError(error, "GET", nbrbRatesAddress);
                result.error = true;
            })
    
    return result;
}
