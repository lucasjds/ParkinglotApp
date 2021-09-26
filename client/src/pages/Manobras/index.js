import React, {useState, useEffect} from 'react';

import {Link, useHistory} from 'react-router-dom';
import {FiEdit, FiTrash2} from 'react-icons/fi';

import api from '../../services/api';

import './style.css';

export default function Manobras(){

    const [manobras, setManobras] = useState([]);
    const [page, setPage] = useState(1);
    const history = useHistory();
    useEffect(() => {
        buscarMaisManobras();
    },[]);

    async function buscarMaisManobras() {
        const response = await api.get(`api/manobra/v1/asc/4/${page}`);
        setManobras([ ...manobras , ...response.data.list]);
        setPage(page + 1);
    }
    
    async function editarManobra(id) {
        try {
            history.push(`manobra/editar/${id}`)
        } catch (err) {
            alert('Falha ao editar!');
        }
    }

    async function deletarManobra(id) {
        try {
            await api.delete(`api/manobra/v1/${id}`);
            setManobras(manobras.filter(manobra => manobra.codigo !== id))
        } catch (err) {
            alert('Falha ao deletar!');
        }
    }

    return (
        <div className="carro-container">
            <header>
                <Link className="button" to="carros">Carros</Link>
                <Link className="button" to="manobristas">Manobristas</Link>
                <Link className="button" to="manobra/novo">Adicionar Manobra</Link>
            </header>
            <h1>Manobras registrados</h1>
            <ul>
                {manobras.map(manobra => (
                    <li key={manobra.codigo}>
                        <strong>Manobrista:</strong>
                        <p>{manobra.manobrista.nome} - {manobra.manobrista.cpf}</p>
                        <strong>Carro:</strong>
                        <p>{manobra.carro.marca} {manobra.carro.modelo}</p> 
                        <p>Placa: {manobra.carro.placa}</p>
                        <strong>Data da manobra:</strong>
                        <p>{Intl.DateTimeFormat('pt-BR').format(new Date(manobra.dataHoraManobra))}</p>
                        <button onClick={() => editarManobra(manobra.codigo)} type="button">
                            <FiEdit size={20} color="#251FC5"/>
                        </button>
                        <button onClick={() => deletarManobra(manobra.codigo)} type="button">
                            <FiTrash2 size={20} color="#251FC5"/>
                        </button>
                    </li>
                ))}
            </ul>
            <button className="button" onClick={buscarMaisManobras} type="button">Carregar Mais</button>
        </div>
    );
}