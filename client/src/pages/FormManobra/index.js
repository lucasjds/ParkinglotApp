import React, {useState, useEffect}  from 'react';
import './style.css';
import {Link, useHistory, useParams } from 'react-router-dom';
import {FiArrowLeft} from 'react-icons/fi';

import api from '../../services/api';

export default function FormManobra(){
    const [codigo, setCodigo] = useState(null);
    const [codigoManobrista, setCodigoManobrista] = useState('');
    const [codigoCarro, setCodigoCarro] = useState('');
    const [dataHoraManobra, setDataHoraManobra] = useState('');
    const [carrosSelect, setCarros] = useState([]);
    const [manobristasSelect, setManobristas] = useState([]);
    const { codigoManobra } = useParams();

    const history = useHistory();

    

    useEffect(() => {
        if(!codigoManobra) return;
        else carregarManobra();
    }, codigoManobra);

    useEffect(() => {
        carregarCarros();
        carregarManobristas();
    },[]);

    async function carregarCarros(){
        const response = await api.get(`api/carro/v1`);
        setCarros(response.data);
    }

    async function carregarManobristas(){
        const response = await api.get(`api/manobrista/v1`);
        setManobristas(response.data);
    }

    async function carregarManobra() {
        
        try {
            const response = await api.get(`api/manobra/v1/${codigoManobra}`)
       
            setCodigo(response.data.codigo);
            setCodigoCarro(response.data.codigoCarro);
            setCodigoManobrista(response.data.codigoManobrista);
            setDataHoraManobra(response.data.dataHoraManobra.split("T", 10)[0]);
            
        } catch (error) {            
            alert('Erro')
            history.push('/manobras');
        }
    }

    async function criarEditarManobra(e){
        e.preventDefault();

        const data = {
            dataHoraManobra,
            codigoCarro,
            codigoManobrista,
        };
        try{
            if(!codigoManobra) {
                await api.post('api/manobra/v1' , data);
            } else {
                data.codigo = codigo;
                await api.put('api/manobra/v1', data);
            }
            
        }catch(err){
            alert('Erro')
        };
        history.push('/manobras');
    }
    return (
        <div className="new-carro-container">
            <div className="content">
                <section className="form">
                    <h1>Formulario manobra</h1>
                    <p>Preencha o formulário e clique em {!codigoManobra? `'Adicionar'` : `'Atualizar'`}</p>
                    <Link className="back-link" to="/manobras">
                        <FiArrowLeft size={16} color="#251FC5"/>
                        Home
                    </Link>
                </section>
                <form onSubmit={criarEditarManobra}>
                    <select placeholder="CodigoCarro" onChange={e => setCodigoCarro(e.target.value)}>
                        <option>Selecione...</option>
                        {carrosSelect.map(carro => (
                            <option selected={codigoCarro == carro.codigo ? 'selected' : ''} value={carro.codigo}>Modelo:{carro.modelo} Placa:{carro.placa}</option>
                        ))}
                    </select>
                    <select placeholder="CodigoManobrista" onChange={e => setCodigoManobrista(e.target.value)}>
                        <option>Selecione...</option>
                        {manobristasSelect.map(manobrista => (
                            <option selected={codigoManobrista == manobrista.codigo ? 'selected' : ''} value={manobrista.codigo}>{manobrista.nome}</option>
                        ))}
                    </select>
                    <input type="date" placeholder="Data" value={dataHoraManobra} onChange={e => setDataHoraManobra(e.target.value)}/>
                    <button className="button" type="submit">{!codigoManobra? 'Adicionar' : 'Atualizar'}</button>
                </form>
            </div>
        </div>
    );

}