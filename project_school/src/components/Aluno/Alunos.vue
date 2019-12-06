<template>
  <div>
    <Titulo texto="Alunos"/>
    <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="addAluno()"/>

    <table border="1px">
    <thead>
      <th>Matrícula</th>
      <th>Nome</th>
      <th>Opções</th>
    </thead>
    <tbody v-if="alunos.length">
      <tr v-for="(aluno, index) in alunos" :key="index">
        <td>{{aluno.id}}</td>
        <td>{{aluno.nome}} {{aluno.sobrenome}}</td>
        <td>
          <Button class="btn" @click="remover(aluno)">Remover</Button>
        </td>
      </tr>
    </tbody>
    <tfoot v-else>
      Nenhum Aluno Encontrado
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
      titulo:'Aluno',
      nome: '',
      alunos: []
    }
  },
  created() {
    this.$http
    .get('http://localhost:3000/alunos')
    .then(res=> res.json())
    .then(alunos=>this.alunos = alunos)
  },
  props: {     
  },
  methods: 
  {
    addAluno() 
    {
      if(this.nome.trim() != '')
      {
        let _aluno={
          nome:this.nome,
          sobrenome: 'padrão'
        }     
        
        this.$http
        .post('http://localhost:3000/alunos',_aluno)
        .then(res=> res.json())
        .then(alunoRetornado => {
          this.alunos.push(alunoRetornado)  
          this.nome = ''
        });

        
      }      
    },
    remover(aluno)
    {
      this.$http
      .delete(`http://localhost:3000/alunos/${aluno.id}`)
      .then(()=>{
        let indice = this.alunos.indexOf(aluno)
        this.alunos.splice(indice, 1)
      })
    }
  }
}
</script>

<style scoped>

</style>
