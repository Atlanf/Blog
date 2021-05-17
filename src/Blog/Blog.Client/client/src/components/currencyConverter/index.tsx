import React from "react";
import { ICurrencyRateList, ICurrency, IConvertedCurrency } from "../../shared/interfaces/currencyConverter.interface";
import { convertCurrencies, loadCurrencyRates, inputIsValid } from "./utils";

interface IProps {
}

interface IState {
    currencyRates: ICurrencyRateList,
    currencyValues: IConvertedCurrency[],
}

const requiredCurrencies: ICurrency[] = [
    {currId: 145, currAbbr: "USD"},
    {currId: 292, currAbbr: "EUR"},
    {currId: 298, currAbbr: "RUB"}
];

const localStorageRatesKey: string = "currencyRates";
const inputLength: number = 12;

export default class CurrencyConverter extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = {
            currencyRates: {rates: [], dateUpdated: "", error: false},
            currencyValues: [
                {currId: 0, currAbbr: "BYN", currValue: "1"},
                {currId: 145, currAbbr: "USD", currValue: "0"},
                {currId: 292, currAbbr: "EUR", currValue: "0"},
                {currId: 298, currAbbr: "RUB", currValue: "0"}
            ]
        }
        this.handleInput = this.handleInput.bind(this);
    }
    
    handleInput(event: React.ChangeEvent<HTMLInputElement>) {
        var val = event.target.value.replace(",", ".");
        var inputName = event.target.name;

        if (inputIsValid(val)) {
            this.setState(() => ({
                currencyValues: convertCurrencies(this.state.currencyRates, val, inputName)
            }));
        }
    }

    async componentDidMount() {
        this.setState({
            currencyRates: await loadCurrencyRates(requiredCurrencies, localStorageRatesKey)
        });
    }
    
    render() {
        let errorDescription = () => {
            return <div></div>
        };
        if (this.state.currencyRates.error) {
            errorDescription = () => {
                return (
                    <div>
                        <p>
                            Error occured on loading currency rates. 
                            Previously loaded values will be used.
                        </p>
                    </div>
                )
            }
        }
        let inputs = this.state.currencyValues.map((val) => {
            return (
                <div>
                    <label>{val.currAbbr}</label>
                    <input type="text" name={val.currAbbr} key={val.currId} onChange={this.handleInput} value={val.currValue} maxLength={inputLength}></input>
                </div>
            );
        })

        return (
            <div>
                <div>
                    {inputs}
                </div>
                <div>
                    {errorDescription}
                </div>
            </div>
        )
    }
}