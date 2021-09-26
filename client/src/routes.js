import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import Carros from './pages/Carros';
import FormCarro from './pages/FormCarro';

import Manobristas from './pages/Manobristas';

export default function Routes(){
    return (
        <BrowserRouter>
            <switch>
                <Route path="/" exact component={Carros}/>
                <Route path="/carros" exact component={Carros}/>
                <Route path="/carro/editar/:codigoCarro" exact component={FormCarro}/>
                <Route path="/carro/novo" exact component={FormCarro}/>

                <Route path="/manobristas" exact component={Manobristas}/>
               
            </switch>
        </BrowserRouter>

    );

}