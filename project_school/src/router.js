import Vue from 'vue';
import Router from 'vue-router'


import Alunos from './components/Aluno/Alunos'
import AlunoDetalhe from './components/Aluno/AlunoDetalhe'
import Professor from './components/Professor/professor'
import Sobre from './components/Sobre/sobre'


Vue.use(Router);

export default new Router({
    routes:[
        {
            path:'/professores', 
            nome:'Professores',
            component: Professor
        },
        {
            path:'/Alunos', 
            nome:'Alunos',
            component: Alunos
        },
        {
            path:'/Alunos/:profId', 
            nome:'Alunos',
            component: Alunos
        },
        {
            path:'/alunoDetalhe/:id', 
            nome:'AlunosDetalhe',
            component: AlunoDetalhe
        },
        {
            path:'/sobre',  
            nome:'Sobre',
            component: Sobre
        }
    ]
})
