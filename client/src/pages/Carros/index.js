import React, {useState, useEffect} from 'react';

import {Link, useHistory} from 'react-router-dom';
import {FiEdit, FiTrash2} from 'react-icons/fi';

import api from '../../services/api';

import './style.css';

export default function Carros(){

    const [carros, setCarros] = useState([]);
    const [page, setPage] = useState(1);
    const history = useHistory();
    useEffect(() => {
        buscarMaisCarros();
    },[]);

    async function buscarMaisCarros() {
        const response = await api.get(`api/carro/v1/asc/4/${page}`);
        setCarros([ ...carros, ...response.data.list]);
        setPage(page + 1);
    }
    
    async function editarCarro(id) {
        try {
            history.push(`carro/editar/${id}`)
        } catch (err) {
            alert('Falha ao editar!');
        }
    }

    async function deletarCarro(id) {
        try {
            await api.delete(`api/carro/v1/${id}`);

            setCarros(carros.filter(carro => carro.codigo !== id))
        } catch (err) {
            alert('Falha ao deletar!');
        }
    }

    return (
        <div className="carro-container">
            <header>
                <Link className="button" to="manobristas">Manobristas</Link>
                <Link className="button" to="manobras">Manobras</Link>
                <Link className="button" to="carro/novo">Adicionar Carro</Link>
            </header>
            <h1>Carros registrados</h1>
            <ul>
                {carros.map(carro => (
                    <li key={carro.codigo}>
                        <strong>Marca:</strong>
                        <p>{carro.marca}</p>
                        <strong>Modelo:</strong>
                        <p>{carro.modelo}</p>
                        <strong>Placa:</strong>
                        <p>{carro.placa}</p>
                        
                        <button onClick={() => editarCarro(carro.codigo)} type="button">
                            <FiEdit size={20} color="#251FC5"/>
                        </button>
                        
                        <button onClick={() => deletarCarro(carro.codigo)} type="button">
                            <FiTrash2 size={20} color="#251FC5"/>
                        </button>
                    </li>
                ))}
            </ul>
            <button className="button" onClick={buscarMaisCarros} type="button">Carregar Mais</button>
        </div>
    );
}