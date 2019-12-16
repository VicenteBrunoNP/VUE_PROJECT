<template>
  <div>
    <Titulo :texto="professorid != undefined ? 'Professor: ' + professor.nome : 'Todos os Alunos'" />
    <div v-if="professorid != undefined">
      <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="addAluno()" />
    </div>

    <table border="1px">
      <thead>
        <th>Matrícula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{aluno.id}}</td>
          <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="td" style="cursor:pointer">{{aluno.nome}} {{aluno.sobrenome}}</router-link>
          <td>
            <Button class="btn" @click="remover(aluno)">Remover</Button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>Nenhum Aluno Encontrado</tfoot>
    </table>
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
      titulo: "Aluno",
      professorid: this.$route.params.prof_id,
      nome: "",
      professor: {},
      alunos: []
    };
  },
  created() {
    if (this.professorid) {
      this.carregarProfessores();
      this.$http
        .get(`http://localhost:5000/api/aluno/ByProfessor/${this.professorid}`)
        .then(res => res.json())
        .then(alunos => (this.alunos = alunos));
    } else {
      this.$http
        .get("http://localhost:5000/api/aluno")
        .then(res => res.json())
        .then(alunos => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    addAluno() {
      if (this.nome.trim() != "") {
        let _aluno = {
          nome: this.nome,
          sobrenome: "",
          professor: {
            id: this.professor.id,
            nome: this.professor.nome
          }
        };

        this.$http
          .post("http://localhost:5000/api/aluno", _aluno)
          .then(res => res.json())
          .then(alunoRetornado => {
            this.alunos.push(alunoRetornado);
            this.nome = "";
          });
      }
    },
    remover(aluno) {
      this.$http.delete(`http://localhost:5000/api/aluno/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
    carregarProfessores() {
      this.$http
        .get("http://localhost:5000/api/professor/" + this.professorid)
        .then(res => res.json())
        .then(prof => {
          this.professor = prof;
        });
    }
  }
};
</script>

<style scoped>
</style>
