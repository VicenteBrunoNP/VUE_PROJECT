<template>
  <div v-if="!loading">
    <titulo :texto="`Aluno: ${aluno.nome}`" :btnVoltar="true">
      <button class="btnEditar" @click="editar()">Editar</button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{aluno.id}}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{aluno.nome}}</label>
            <input v-else v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome</td>
          <td>
            <label v-if="visualizando">{{aluno.sobrenome}}</label>
            <input v-else v-model="aluno.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento</td>
          <td>
            <label v-if="visualizando">{{aluno.dataNasc}}</label>
            <input v-else v-model="aluno.dataNasc" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor</td>
          <td>
            <label v-if="visualizando">{{aluno.professor.nome}}</label>
            <select v-else v-model="aluno.professor">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                :value="professor.id"
              >{{professor.nome}}</option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div>
      <div style="margun-top:10px">
        <div v-if="!visualizando">
          <button class="btn btnSalvar" @click="salvar(aluno)">Salvar</button>
          <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../_Share/Titulo";
export default {
  components: {
    Titulo
  },
  data() {
    return {
      professores: {},
      aluno: {},
      idAluno: this.$route.params.id,
      visualizando: true,
      loading: true
    };
  },
  created() {
    this.carregarProfessor();
  },
  methods: {
    carregarProfessor() {
      this.$http
        .get("http://localhost:5000/api/professor")
        .then(res => res.json())
        .then(professor => {
            this.professores = professor;
            this.carregarAluno();
        });
    },
    carregarAluno() {
      this.$http
        .get("http://localhost:5000/api/aluno/" + this.idAluno)
        .then(res => res.json())
        .then(alunos => {
            this.aluno = alunos;
            this.loading = false;
        });
    },
    editar() {
      this.visualizando = !this.visualizando;
    },
    salvar(_aluno) {
      let _alunoEditar = {
        id: _aluno.id,
        nome: _aluno.nome,
        sobrenome: _aluno.sobrenome,
        dataNasc: _aluno.dataNasc,
        professorid: _aluno.professor.id
      };

      this.$http
        .put(`http://localhost:5000/api/aluno/${_alunoEditar.id}`, _alunoEditar)
        .then(res => res.json())
        .then(aluno => this.aluno = aluno)
        .then(()=>this.visualizando = true);

      this.visualizando = !this.visualizando;
    },
    cancelar() {
      this.visualizando = !this.visualizando;
    }
  }
};
</script>

<style scoped>
.colPequeno {
  width: 20%;
  text-align: right;
  background: #4f4ff1;
  color: #fff;
}
input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border-radius: 5px;
  border: 1px solid silver;
  font-family: Montserrat;
  width: 95%;
}
select {
  height: 38px;
  width: 98%;
}

.btnEditar {
  float: right;
}
</style>