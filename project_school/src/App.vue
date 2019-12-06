<template>
  <div id="app">
    <Alunos/>
  </div>
</template>

<script>
import Alunos from './components/Aluno/Alunos.vue'

export default {
  name: 'app',
  components: {
    Alunos
  }
}
</script>

<style>

body{
  background: #eeeeee;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  display: grid;
  justify-items: center;
}
body,html{
  margin: 0;
  height: 100%;
}

table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}

table thead th{
  padding: 20px;
  font-size: 1.3em;
  padding: 10px 10px;
  background-color:#dddd00;
}

table tr td{
  padding: 20px;
  font-size: 1.3em;
  padding: 10px 10px;
  background-color:#e0edfe;
}

.colPequeno{
  width: 5%;
}

#app {
}
</style>
