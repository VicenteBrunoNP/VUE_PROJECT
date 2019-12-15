<template>
  <div>
    <Titulo texto="Professor"/>

    <table border="1px">
    <thead>
      <th>Cód.</th>
      <th>Nome</th>
      <th>Alunos</th>
    </thead>
    <tbody v-if="professores.length">
      <tr v-for="(professor, index) in professores" :key="index">
        <td>{{professor.id}}</td>        
        <router-link :to="`/aluno/${professor.id}`" tag="td" style="cursor:pointer">
          {{professor.nome}} {{professor.sobrenome}}
        </router-link>
        <td>{{professor.qtdAlunos}}</td>
      </tr>
    </tbody>
    <tfoot v-else>
      Nenhum Professor Encontrado
    </tfoot>
  </table>
  
  </div>
  
</template>

<script>

import Titulo from '../_Share/Titulo';

export default {
  components:{
    Titulo
  },
  data(){
    return{
      professores: [],
      alunos:[],      
    }
  },
  created() {
    this.$http
    .get('http://localhost:3000/alunos')
    .then(res=> res.json())
    .then(aluno=>{
      this.alunos = aluno
      this.carregarProfessores()
      })
  },
  props: {     
  },
  methods: {
    pegarQtdAlunosPorProfessor(){
      this.professores.forEach((professor, index) => {
        professor =
        {
          id: professor.id,
          nome: professor.nome,
          qtdAlunos: this.alunos.filter(aluno=>
            aluno.professor.id == professor.id
          ).length
        }
        this.professores[index] = professor        
      });
    },
    carregarProfessores(){
      this.$http
      .get('http://localhost:3000/professores')
      .then(res=> res.json())
      .then(professor=>{
        this.professores = professor
        this.pegarQtdAlunosPorProfessor()
      })
    }
  },
}
</script>

<style scoped>

</style>
