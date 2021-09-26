import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import Carros from './pages/Carros';

export default function Routes(){
    return (
        <BrowserRouter>
            <switch>
            <Route path="/" exact component={Carros}/>
                <Route path="/carros" exact component={Carros}/>
            </switch>
        </BrowserRouter>

    );

}