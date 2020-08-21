<template>
  <div>
    <title>Professores</title>
    <Titulo :texto="`Aluno: ${Aluno.nome} ${Aluno.sobreNome}`" :btnVoltar="!mostrar">
      <button @click="exibir()" class="btn btnEditar">Editar</button>
    </Titulo>
    <table>
      <tr>
        <td class="colPequeno">Matrícula:</td>
        <td>{{Aluno.id}}</td>
      </tr>
      <tr>
        <td class="colPequeno">Nome:</td>
        <td>
          <label v-if="mostrar == false">{{Aluno.nome}}</label>
          <input v-else v-model="Aluno.nome" type="text" value />
        </td>
      </tr>
      <tr>
        <td class="colPequeno">Sobrenome:</td>
        <td>
          <label v-if="mostrar == false">{{Aluno.sobreNome}}</label>
          <input v-else v-model="Aluno.sobreNome" type="text" value />
        </td>
      </tr>
      <tr>
        <td class="colPequeno">Data de nascimento:</td>
        <td>
          <label v-if="mostrar == false">{{Aluno.dataNasc}}</label>
          <input v-else v-model="Aluno.dataNasc" type="text" value />
        </td>
      </tr>
      <tr>
        <td class="colPequeno">Professor</td>
        <td>
          <label v-if="mostrar == false">{{Aluno.professor.nome}} {{Aluno.professor.sobreNome}}</label>
          <select v-else v-model="Aluno.professor">
            <option
              v-for="(professor, index) in professores"
              :key="index"
              v-bind:value="professor"
            >{{professor.nome}} {{professor.sobreNome}}</option>
          </select>
        </td>
      </tr>
    </table>
    <div class="btnFooter">
      <button v-show="mostrar" @click="cancelar()" class="btn btnCancelar">Cancelar</button>
      <button v-show="mostrar" @click="salvar(Aluno)" class="btn btnSalvar">Salvar</button>
    </div>
  </div>
</template>

<script>
import Titulo from "../_share/titulo";

export default {
  components: {
    Titulo,
  },

  data() {
    return {
      Aluno: {},
      professores: [],
      mostrar: false,
      id: this.$route.params.id,
    };
  },
  created() {
    this.listarAlunos();
    this.listaProfessores();
  },
  methods: {
    listarAlunos() {
      this.$http
        .get("http://localhost:3000/alunos/" + this.id)
        .then((res) => res.json())
        .then((alunos) => (this.Aluno = alunos));
    },
    listaProfessores() {
      this.$http
        .get("http://localhost:3000/professores")
        .then((result) => result.json())
        .then((_professores) => {
          this.professores = _professores;
        });
    },
    exibir() {
      this.mostrar = !this.mostrar;
    },
    cancelar(){
      this.mostrar = !this.mostrar;
      
    },

    salvar(){
     let alunoEditado = {
      id: this.Aluno.id,
      nome:this.Aluno.nome, 
      sobreNome:this.Aluno.sobreNome,
      dataNasc:this.Aluno.dataNasc,
      professor:this.Aluno.professor
      }

       this.$http
        .put("http://localhost:3000/alunos/" + alunoEditado.id, alunoEditado);
         this.mostrar = !this.mostrar;
        this.$toast.open({
          message: 'Editado com sucesso.',
          type:'success',
          position: 'top-right'
        })
        
    }
  },
};
</script>


<style  scoped>



.btnEditar {
  background-color: #46c28e;
  float: right;
}
.btnSalvar {
  background-color: #46c28e;
}
.btnFooter{
  margin-top: 15px;
}

.btnCancelar {
  background-color: #e7432d;
  float: right;
 
}
</style>