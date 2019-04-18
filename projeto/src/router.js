import Vue from 'vue';
import Router from 'vue-router'
import Funcionarios from './components/Funcionario/Funcionarios'
import FuncionarioDetalhe from './components/Funcionario/FuncionarioDetalhe'

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/todosFuncionarios',
            nome: 'Funcionarios',
            component: Funcionarios
        },
        {
            path: '/funcionarioDetalhe/:id',
            nome: 'FuncionarioDetalhe',
            component: FuncionarioDetalhe
        }
    ]
})