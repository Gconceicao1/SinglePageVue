<template>
  <div id>
    <titulo
      :texto=" professor.id !== undefined ? `Alunos de ${professor.nome} ${professor.sobreNome}`: 'Todos os alunos'"
    />
    <div v-if="professor.id !== undefined">
      <input
        class="inputText"
        type="text"
        placeholder="Nome do aluno"
        v-model="nome"
        v-on:keyup.enter="add()"
      />
      <input
        class="inputText"
        type="text"
        placeholder="Sobre nome do aluno"
        v-model="sobreNome"
        v-on:keyup.enter="add()"
      />
      <button class="btn btnSucess" @click="add()">Adicionar</button>
    </div>
    <table>
      <thead>
        <th>Matricula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{aluno.id}}</td>
          <router-link
            tag="td"
            :to="`/alunoDetalhe/${aluno.id}`"
            class="routerLink"
            style="cursor:pointer"
          >{{aluno.nome}} {{aluno.sobreNome}}</router-link>

          <td>
            <button class="btn btnRemover" @click="remover(aluno)">remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <h4>Nenhum aluno encontrado</h4>
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
      titulo: "Alunos",
      nome: "",
      sobreNome: "",
      alunos: [],
      profId: this.$route.params.profId,
      professor: {},
    };
  },

  created() {
    if (this.profId) {
      this.listarProfessor();
      this.ListarAlunosPorProfessor();
    } else {
      this.listarAlunos();
    }
  },
  props: {},
  methods: {
    listarAlunos() {
      this.$http
        .get("http://localhost:3000/alunos")
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    },

    ListarAlunosPorProfessor() {
      this.$http
        .get("http://localhost:3000/alunos?professor.id=" + this.profId)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    },

    add() {
      let _alunos = {
        nome: this.nome,
        sobreNome: this.sobreNome,
        professor: {
          id: this.professor.id,
          nome: this.professor.nome,
        },
      };
      this.$http
        .post("http://localhost:3000/alunos", _alunos)
        .then((res) => res.json())
        .then((alunoResponse) => {
          this.alunos.push(alunoResponse);
          

          this.$toast.open({
            message: `Aluno (a) ${this.nome} inserido (a) com sucesso`,
            type: "success",
            position: "top-right",
          });

        (this.nome = ""), (this.sobreNome = "");

        });
    },

    remover(aluno) {
      this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`)
      .then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
         
         this.$toast.open({
           message: `Aluno(a) removido com sucesso`,
            type: "success",
            position: "top-right",
          });
      });
    },

    //Professores
    listarProfessor() {
      this.$http
        .get(`http://localhost:3000/professores/${this.profId}`)
        .then((result) => result.json())
        .then((professor) => {
          this.professor = professor;
        });
    },
  },
};
</script>
<style scoped>
.inputText {
  padding: 10px;
  color: gray;
  border: 0;
  width: calc(100% - 550px);
}
.inputText {
  padding: 10px;
  margin: 2px;
  border-radius: 4px;
  font-family: "Montserrat", sans-serif;
  size: 1.2em;
}
.btnSucess {
  background-color: #07bc4c;
  margin: 2px;
  display: inline;
}
.btn .btnSucess:hover {
  padding-top: 20px;
  margin: 0;
  border: 2px solid black;
}

tfoot {
  justify-items: center;
}
.routerLink:hover {
  background-color: rgb(158 154 154);
  color: #fff;
}
</style>
<!-- Add "scoped" attribute to limit CSS to this component only -->

