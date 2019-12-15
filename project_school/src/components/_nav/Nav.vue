<template>
    <div class="barraTop">
        <nav class="marginPrincipal">
            <router-link to="/professor">Professor</router-link>
            <router-link to="/todosalunos">Aluno</router-link>
            <router-link to="/sobre">Sobre</router-link>
        </nav>
    </div>
</template>

<script>
    export default {
        
    }
</script>

<style scoped>
.barraTop{
    background: rgb(230, 230, 230)
}

nav{
    padding: 20px 20px 20px 0px;
}
nav a{
    padding: 10px;
    text-decoration: none;
    background: #ffffff;
    color:rgb(0, 110, 255);
    font-weight: bold;
    margin-right: 15px;
    border-radius:3px;
}
nav .router-link-exact-active{
    background: #888888;
    color: #ffffff
}
</style>