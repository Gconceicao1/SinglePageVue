<template>
  <div>
    <titulo texto="Professores" />
    <alunosC />
    <table>
      <thead>
        <th>Cód.</th>
        <th>Nome</th>
        <th>Diciplina</th>
        <th>Qtde Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(professor, index) in professores" :key="index">
          <td>{{professor.id}}</td>
          
              <router-link v-bind:to="`/alunos/${professor.id}`" tag="td" style="cursor:pointer"> 
             
              {{professor.nome}} {{professor.sobreNome}}
              
               </router-link> 
          
          <td >{{professor.materia}}</td>
          <td>    
              {{professor.qtdeAlunos}} 
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <h4>Nenhum professor encontrado</h4>
      </tfoot>
    </table>
  </div>
</template>

<script>
import titulo from "../_share/titulo";

export default {
  components: {
    titulo,
  },
  data() {
    return {
      professores: [],
      alunos: [],
    };
  },

  created() {
    this.$http
      .get("http://localhost:3000/alunos")
      .then((res) => res.json())
      .then((alunos) => {
        this.alunos = alunos;
        this.listaProfessores();
      });
  },

  props: {},

  methods: {
    qtdeAlunosProfessor() {
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          sobreNome: professor.sobreNome,
          materia: professor.materia,
          qtdeAlunos: this.alunos.filter((aluno) => {
            return aluno.professor.id == professor.id;
          }).length,
        };
        this.professores[index] = professor;
      });
    },

    listaProfessores() {
      this.$http
        .get("http://localhost:3000/professores")
        .then((result) => result.json())
        .then((professores) => {
          this.professores = professores;
          this.qtdeAlunosProfessor();
        });
    },
  },
};
</script>

<style scoped>
</style>