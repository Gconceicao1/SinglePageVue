<template>
  <div class="barraTop">
    <nav class="marginPrincipal">
      <router-link to="/professores">Professores</router-link>
      <router-link to="/alunos">Alunos</router-link>
      <router-link to="/sobre">Sobre</router-link>
    </nav>
  </div>
</template>

<script>
export default {};
</script>

<style  scoped>
.marginPrincipal {
  width: 50%;
  margin: auto;
}
.barraTop {
  background: #0e76fd;
}

nav .router-link-active {
  color: rgb(31, 30, 30);
}

nav {
  padding: 20px 20px 20px 0px;
  width: 100%;
}
nav a {
  padding: 10px;
  text-decoration: none;
  color: #fff;
  font-weight: bold;
  margin-right: 15px;
}
nav a:hover {
  color: rgb(31, 30, 30);
}
</style>