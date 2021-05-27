import React from 'react';
import { CurrencyConverter } from './components';
import { UserProjectsPage } from './pages/userProjectsPage';

function App() {
    return (
        <div>
            <UserProjectsPage />
            <CurrencyConverter />
        </div>
    );
}

export default App;
