import React from "react";
import { CreateUserProject, CurrencyConverter } from '../components';

export const HomePage: React.FC = () => {
    return (
        <div>
            <CreateUserProject />
            <CurrencyConverter />
        </div>
    )
}