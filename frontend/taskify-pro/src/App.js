
import { useState, useEffect } from 'react';
import './App.css';
import AtividadeForm from './components/AtividadeForm';
import AtividadeLista from './components/AtividadeLista';

function App() {
  const [index, setIndex] = useState (0);
  const [atividades, setAtividades] = useState([])
  const [atividade, setAtividade] = useState({id: 0})

  useEffect(() => {
    atividades.length <= 0 ? setIndex(1) 
    : setIndex(Math.max.apply( Math, atividades.map( item => item.id) ) + 1 )
  }, [atividades])

function addAtividade(ativ){
  
  setAtividades([ ...atividades, { ...ativ, id: index}]);
}

function pegarAtividade(id){
  const ativSelecionada = atividades.filter(atividades => atividades.id === id);
  setAtividade(ativSelecionada[0]);
}

function cancelarAtividade(ativ){
  setAtividade({id:0});
}

function atualizarAtividade(ativ){
  console.log(ativ.titulo)
  setAtividades(atividades.map(item => item.id === ativ.id ? ativ : item));  
  setAtividade({id:0});
}

function deletarAtividade(id){
  const atividadesFiltradas = atividades.filter(atividades => atividades.id !== id);
setAtividades([ ...atividadesFiltradas]);
}

  return (
    <>
      <AtividadeForm 
        atividades={atividades}
        ativSelecionada={atividade}
        addAtividade={addAtividade}
        cancelarAtividade={cancelarAtividade}
        atualizarAtividade={atualizarAtividade}
      />
      <AtividadeLista 
        atividades={atividades}
        deletarAtividade={deletarAtividade}
        pegarAtividade={pegarAtividade}
      />
    </>
  );
}

export default App;
