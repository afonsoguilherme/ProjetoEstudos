<template>
  <div>
    <div>
    <Titulo texto="Funcionários"/>
      <input
        type="text"
        placeholder="Nome do Funcionário"
        v-model="nomeFuncionario"
        @keyup.enter="addFuncionario()"
      >
      <button class="btn btnInput" @click="addFuncionario()">Adicionar</button>
    </div>
    <table>
      <thead>
        <th>Código</th>
        <th>Nome</th>
        <th>Idade</th>
        <th>Função</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="funcionarios.length">
        <tr v-for="(Funcionario, index) in funcionarios" :key="index">
          <td class="colPequeno" style="text-align: center; width: 15%">{{index+1}}</td>
          <router-link
            :to="`/funcionarioDetalhe/${Funcionario.idFuncionario}`"
            tag="td"
            style="cursor: pointer"
          >{{Funcionario.nomeFuncionario}}</router-link>
          <td>{{Funcionario.idadeFuncionario}}</td>
          <td>{{Funcionario.funcaoFuncionario}}</td>
          <td>
            <button class="btn btn_Danger" @click="remover(Funcionario)">Remover</button>
          </td>
          
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Funcionário Encontrado</h5>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";
export default {
  components: {
    Titulo
  },
  data() {
    return {
      Titulo: "Funcionários",
      nomeFuncionario: "",
      funcionarios: []
    };
  },
  created(){
    this.$http
    .get('http://localhost:5000/api/Funcionario/ObterTodosFuncionarios')
    .then(res => res.json())
    .then(funcionarios => this.funcionarios = funcionarios)
  },
  props: {},
  methods: {
    addFuncionario() {
      let _funcionario = {
        nomeFuncionario: this.nomeFuncionario,
        idadeFuncionario: "",
        funcaoFuncionario: ""

      };
      this.$http
        .post("http://localhost:5000/api/Funcionario/AdcionarNovoFuncionario", _funcionario)
        .then(res => res.json())
        .then(Funcionario => {
          this.Funcionarios.push(Funcionario);
          this.nomeFuncionario = "";
        });
    },
     remover(Funcionario) {
      this.$http
        .delete(`http://localhost:5000/api/Funcionario/DeletarFuncionario/${Funcionario.idFuncionario}`)
        .then(() => {
          let indice = this.funcionarios.indexOf(Funcionario);
          this.funcionarios.splice(indice, 1);
        });
    }
  }
};
</script>

<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}
.btnInput {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 155);
  display: inline;
}
.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
