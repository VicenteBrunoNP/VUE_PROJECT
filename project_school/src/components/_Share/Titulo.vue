<template>
    <div>
        <div style="display:flex;width:50%">
            <h1>{{texto}}</h1>
            <div class="voltar">
                <button v-show="btnVoltar" class="btn btnVoltar" @click="voltar()">Voltar</button>
                <slot></slot>
            </div>
            
        </div>
    </div>
</template>

<script>
    export default {
        props:{
            texto:String,
            btnVoltar:Boolean
        },
        methods: {
            voltar(){
                this.$router.back();
            }
        },
    }
</script>

<style scoped>
.voltar{
    position: absolute;
    width: 50%;
    margin-top:15px;
}
.btnVoltar{
    float:right
}
</style>