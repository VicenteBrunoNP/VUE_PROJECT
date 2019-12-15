import Vue from 'vue';
import Router from 'vue-router';
import Aluno from './components/Aluno/Aluno'
import AlunoDetalhe from './components/Aluno/AlunoDetalhe'
import Professor from './components/Professor/Professor'
import Sobre from './components/Sobre/Sobre'

Vue.use(Router)

export default new Router({
    routes:[
        {
            path: '/professor',
            nome: 'Professor',
            component: Professor
        },
        {
            path: '/aluno/:prof_id',
            nome: 'Aluno',
            component: Aluno
        },
        {
            path: '/todosalunos',
            nome: 'Aluno',
            component: Aluno
        },
        {
            path: '/alunoDetalhe/:id',
            nome: 'AlunoDetalhe',
            component: AlunoDetalhe
        },
        {
            path: '/sobre',
            nome: 'Sobre',
            component: Sobre
        }
    ]
})