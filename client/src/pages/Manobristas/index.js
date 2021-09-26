import React, {useState, useEffect} from 'react';

import {Link, useHistory} from 'react-router-dom';
import {FiEdit, FiTrash2} from 'react-icons/fi';

import api from '../../services/api';

import './style.css';

export default function Manobristas(){

    const [manobristas, setManobristas] = useState([]);
    const [page, setPage] = useState(1);
    const history = useHistory();
    useEffect(() => {
        buscarMaisManobristas();
    },[]);

    async function buscarMaisManobristas() {
        const response = await api.get(`api/manobrista/v1/asc/4/${page}`);
        setManobristas([ ...manobristas , ...response.data.list]);
        setPage(page + 1);
    }
    
    async function editarManobrista(id) {
        try {
            history.push(`manobrista/editar/${id}`)
        } catch (err) {
            alert('Falha ao editar!');
        }
    }

    async function deletarManobrista(id) {
        try {
            await api.delete(`api/manobrista/v1/${id}`);

            setManobristas(manobristas.filter(manobrista => manobrista.codigo !== id))
        } catch (err) {
            alert('Falha ao deletar!');
        }
    }

    return (
        <div className="carro-container">
            <header>
                <Link className="button" to="carros">Carros</Link>
                <Link className="button" to="manobras">Manobras</Link>
                <Link className="button" to="manobrista/novo">Adicionar Manobrista</Link>
            </header>
            <h1>Manobristas registrados</h1>
            <ul>
                {manobristas.map(manobrista => (
                    <li key={manobrista.codigo}>
                        <strong>Nome:</strong>
                        <p>{manobrista.nome}</p>
                        <strong>Data nascimento:</strong>
                        <p>{Intl.DateTimeFormat('pt-BR').format(new Date(manobrista.dataNascimento))}</p>
                        <strong>CPF:</strong>
                        <p>{manobrista.cpf}</p>
                        
                        <button onClick={() => editarManobrista(manobrista.codigo)} type="button">
                            <FiEdit size={20} color="#251FC5"/>
                        </button>
                        
                        <button onClick={() => deletarManobrista(manobrista.codigo)} type="button">
                            <FiTrash2 size={20} color="#251FC5"/>
                        </button>
                    </li>
                ))}
            </ul>
            <button className="button" onClick={buscarMaisManobristas} type="button">Carregar Mais</button>
        </div>
    );
}