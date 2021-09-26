import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import Carros from './pages/Carros';
import FormCarro from './pages/FormCarro';

import Manobristas from './pages/Manobristas';
import FormManobrista from './pages/FormManobra';

import Manobras from './pages/Manobras';
import FormManobra from './pages/FormManobrista';

export default function Routes(){
    return (
        <BrowserRouter>
            <switch>
                <Route path="/" exact component={Carros}/>
                <Route path="/carros" exact component={Carros}/>
                <Route path="/carro/editar/:codigoCarro" exact component={FormCarro}/>
                <Route path="/carro/novo" exact component={FormCarro}/>

                <Route path="/manobristas" exact component={Manobristas}/>
                <Route path="/manobrista/editar/:codigoManobrista" exact component={FormManobrista}/>
                <Route path="/manobrista/novo" exact component={FormManobrista}/>

                <Route path="/manobras" exact component={Manobras}/>
                <Route path="/manobra/editar/:codigoManobra" exact component={FormManobra}/>
                <Route path="/manobra/novo" exact component={FormManobra}/>
            </switch>
        </BrowserRouter>

    );

}