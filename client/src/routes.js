import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import Carros from './pages/Carros';
import FormCarro from './pages/FormCarro';

export default function Routes(){
    return (
        <BrowserRouter>
            <switch>
                <Route path="/" exact component={Carros}/>
                <Route path="/carros" exact component={Carros}/>
                <Route path="/carro/novo/:codigoCarro" exact component={FormCarro}/>
            </switch>
        </BrowserRouter>

    );

}