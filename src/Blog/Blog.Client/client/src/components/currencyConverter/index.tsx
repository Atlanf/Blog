import React from "react";
import { ICurrencyRateList, ICurrencies, IConvertedCurrencies } from "./types";
import { convertCurrencies, loadCurrencyRates } from "./utils";

interface IProps {
}

interface IState {
    currencyRates: ICurrencyRateList,
    currencyValues: IConvertedCurrencies[]
}

const requiredCurrencies: ICurrencies[] = [
    {currId: 145, currAbbr: "USD"},
    {currId: 292, currAbbr: "EUR"},
    {currId: 298, currAbbr: "RUB"}
];

const requestUrl: string = "https://www.nbrb.by/api/exrates/rates?periodicity=0";
const localStorageRatesKey: string = "currencyRates";

export default class CurrencyConverter extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = {
            currencyRates: {rates: [], dateUpdated: ""},
            currencyValues: [
                {currId: 0, currAbbr: "BYN", currValue: 1},
                {currId: 145, currAbbr: "USD", currValue: 0},
                {currId: 292, currAbbr: "EUR", currValue: 0},
                {currId: 298, currAbbr: "RUB", currValue: 0}
            ]
        }
        this.handleInput = this.handleInput.bind(this);
    }
    
    handleInput(event: React.ChangeEvent<HTMLInputElement>) {
        var val = Number(event.target.value);
        var inputName = event.target.name;

        this.setState(() => ({
            currencyValues: convertCurrencies(this.state.currencyRates, val, inputName)
        }));
    }

    async componentDidMount() {
        this.setState({
            currencyRates: await loadCurrencyRates(requiredCurrencies, requestUrl, localStorageRatesKey)
        });
    }
    
    render() {
        return (
            <div>
                {this.state.currencyValues.map((val) => {
                    return (
                        <div>
                            <label>{val.currAbbr}</label>
                            <input type="text" name={val.currAbbr} key={val.currId} onChange={this.handleInput} value={val.currValue}></input>
                        </div>
                    );
                })}
            </div>
        )
    }
}