import React from 'react';
import Switch from 'react-bootstrap/esm/Switch';
import { BrowserRouter, Route } from 'react-router-dom';
import { UserTasksPage, HomePage, UserProjectsPage } from './pages';

import { NavBar } from "./components/navBar";

function App() {
    return (
        <div>
            <NavBar />
            <BrowserRouter>
                <Switch>
                    <Route exact path="/" component={HomePage} />
                    <Route path="/projects/details/:shortName" component={UserTasksPage} />
                    <Route path="/projects" component={UserProjectsPage} />
                </Switch>
            </BrowserRouter>
        </div>
    );
}

export default App;
