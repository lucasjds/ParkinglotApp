import React, {useState, useEffect}  from 'react';
import './style.css';
import {Link, useHistory, useParams } from 'react-router-dom';
import {FiArrowLeft} from 'react-icons/fi';

import api from '../../services/api';

export default function FormManobrista(){
    const [codigo, setCodigo] = useState(null);
    const [nome, setNome] = useState('');
    const [dataNascimento, setDataNascimento] = useState('');
    const [cpf, setCpf] = useState('');

    const { codigoManobrista } = useParams();

    const history = useHistory();

    useEffect(() => {
        if(!codigoManobrista) return;
        else carregarManobrista();
    }, codigoManobrista);

    async function carregarManobrista() {
        try {
            const response = await api.get(`api/manobrista/v1/${codigoManobrista}`)
       
            setCodigo(response.data.codigo);
            setNome(response.data.nome);
            setDataNascimento(response.data.dataNascimento.split("T", 10)[0]);
            setCpf(response.data.cpf);
        } catch (error) {            
            alert('Erro')
            history.push('/manobristas');
        }
    }

    async function criarEditarManobrista(e){
        e.preventDefault();

        const data = {
            nome,
            dataNascimento,
            cpf,
        };
        try{
            if(!codigoManobrista) {
                await api.post('api/manobrista/v1' , data);
            } else {
                data.codigo = codigo;
                await api.put('api/manobrista/v1', data);
            }
            
        }catch(err){
            alert('Erro')
        };
        history.push('/manobristas');
    }

    return (
        <div className="new-carro-container">
            <div className="content">
                <section className="form">
                    <h1>Formulario manobrista</h1>
                    <p>Preencha o formulário e clique em {!codigoManobrista? `'Adicionar'` : `'Atualizar'`}</p>
                    <Link className="back-link" to="/manobristas">
                        <FiArrowLeft size={16} color="#251FC5"/>
                        Home
                    </Link>
                </section>
                <form onSubmit={criarEditarManobrista}>
                    <input placeholder="Nome" value={nome} onChange={e => setNome(e.target.value)}/>
                    <input type="date" placeholder="Data" value={dataNascimento} onChange={e => setDataNascimento(e.target.value)}/>
                    <input placeholder="CPF" value={cpf} onChange={e => setCpf(e.target.value)}/>
                    <button className="button" type="submit">{!codigoManobrista? 'Adicionar' : 'Atualizar'}</button>
                </form>
            </div>
        </div>
    );

}