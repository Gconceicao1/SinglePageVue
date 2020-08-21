<template>
  <div>
    <div class="tituloGroup">
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
  props: {
    texto: String,
    btnVoltar: Boolean,
  },
  methods: {
    voltar() {
      this.$router.back();
    },
  },
};
</script>

<style scoped>
h1 {
  color: #000;
}
.btnVoltar {
  background-color: #0e74f0;
  float: right;
  margin-left: 15px;
}
.voltar {
  width: 50%;
  position: absolute;
  margin-top: 30px;
}

.tituloGroup {
  display: flex;
  width: 50%;
}
</style>