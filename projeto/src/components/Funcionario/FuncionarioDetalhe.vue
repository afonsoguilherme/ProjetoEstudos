<template>
  <div >
    <titulo :texto="`Funcionário: ${funcionario.nomeFuncionario}`" />
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Código:</td>
          <td>
            <label>{{funcionario.idFuncionario}}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{funcionario.nomeFuncionario}}</label>
            <input v-else v-model="funcionario.nomeFuncionario" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Idade:</td>
          <td>
            <label v-if="visualizando">{{funcionario.idadeFuncionario}}</label>
            <input v-else v-model="funcionario.idadeFuncionario" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Função:</td>
          <td>
            <label v-if="visualizando">{{funcionario.funcaoFuncionario}}</label>
            <input v-else v-model="funcionario.funcaoFuncionario" type="text">
          </td>
        </tr>
      </tbody>
    </table>
    <div style="margin-top: 10px">
      <div v-if="!visualizando">
        <button class="btn btnSalvar" @click="salvar(funcionario)">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
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
      funcionario: {},
      id: this.$route.params.id,
    };
  },
  created(){
    this.$http
        .get(`http://localhost:5000/api/Funcionario/ObterFuncionariosPorId/${this.id}`)
        .then(res => res.json())
        .then(funcionario => {
          this.funcionario = funcionario;
        });
  },
  methods: {
    
}
};

</script>
<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}
.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}
.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}
.colPequeno {
  width: 20%;
}
input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  background-color: rgb(245, 245, 245);
  width: 95%;
}
select {
  height: 38px;
  width: 100%;
}
</style>