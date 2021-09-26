import React, {useState, useEffect}  from 'react';
import './style.css';
import {Link, useHistory, useParams } from 'react-router-dom';
import {FiArrowLeft} from 'react-icons/fi';

import api from '../../services/api';

export default function FormCarro(){
    const [codigo, setCodigo] = useState(null);
    const [marca, setMarca] = useState('');
    const [modelo, setModelo] = useState('');
    const [placa, setPlaca] = useState('');

    const { codigoCarro } = useParams();

    const history = useHistory();

    useEffect(() => {
        if(codigoCarro === '0') return;
        else carregarCarro();
    }, codigoCarro);

    async function carregarCarro() {
        try {
            const response = await api.get(`api/carro/v1/${codigoCarro}`)
            
            setCodigo(response.data.codigo);
            setMarca(response.data.marca);
            setModelo(response.data.modelo);
            setPlaca(response.data.placa);
        } catch (error) {            
            alert('Erro')
            history.push('/carros');
        }
    }

    async function criarEditarCarro(e){
        e.preventDefault();

        const data = {
            marca,
            modelo,
            placa,
        };
        try{
            if(codigoCarro === '0') {
                await api.post('api/carro/v1' , data);
            } else {
                data.codigo = codigo;
                await api.put('api/carro/v1', data);
            }
            
        }catch(err){
            alert('Erro')
        };
        history.push('/carros');
    }

    return (
        <div className="new-carro-container">
            <div className="content">
                <section className="form">
                    <h1>Adicionar novo carro</h1>
                    <p>Preencha o formulário e clique em {codigoCarro === '0'? `'Adicionar'` : `'Atualizar'`}</p>
                    <Link className="back-link" to="/carros">
                        <FiArrowLeft size={16} color="#251FC5"/>
                        Home
                    </Link>
                </section>
                <form onSubmit={criarEditarCarro}>
                    <input placeholder="Marca" value={marca} onChange={e => setMarca(e.target.value)}/>
                    <input placeholder="Modelo" value={modelo} onChange={e => setModelo(e.target.value)}/>
                    <input placeholder="Placa" value={placa} onChange={e => setPlaca(e.target.value)}/>
                    <button className="button" type="submit">{codigoCarro === '0'? 'Adicionar' : 'Atualizar'}</button>
                </form>
            </div>
        </div>
    );

}