import React from 'react';
import { CreateUserProject, CurrencyConverter } from './components';
import { UserProjectsPage } from './pages/userProjectsPage';

function App() {
    return (
        <div>
            {/* <UserProjectsPage /> */}
            <CreateUserProject />
            <CurrencyConverter />
        </div>
    );
}

export default App;
