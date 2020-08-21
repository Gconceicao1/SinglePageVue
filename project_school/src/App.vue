<template>
  <div id="app">
    <Nav/>
    <div class="marginPrincipal">
      <router-view :key="$route.fullPath"></router-view>
      
    </div>
   
  </div>
</template>

<script>
import Nav from './components/_nav/nav'


export default {
  name: 'App',
  components: {
    Nav,
    
    
  }
}
</script>

<style >
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@300&display=swap');

#app{
  width:100% ;
}

.marginPrincipal{
  width: 50%;
  margin: auto;
}

body ,html{
  margin:0;
  height:100%;
}

body{
  background-color: #e8eff8;
  font-family: 'Montserrat', sans-serif;
  display: grid;
  justify-items: center;
}
table{
  margin:0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
  background-color: #ffffff
  
}
table tr td{
  background-color: rgb(240, 240, 240);
  font-size: 1.3em;
  padding: 20px 5px;
  text-align: center;
  margin-bottom: 2px;
  color: #3e5252;
}
table thead th{
  background-color: #a7c5ec;
  font-size: 1.2em;
  padding: 10px 5px;
  text-align: center;
}



.btnRemover{
background-color: #eb3636;
}

.btn{
  border: 2px solid black;
  border-bottom: 5px solid black;
  border-radius: 3px;
  padding: 10px 10px;
  font-weight: bold;
  cursor: pointer; 
  color: white;
}
.btn:hover{
  color: white;
  border-bottom: 2px solid black;
  margin-top:2px;
  padding-top: 11px;
}
.colPequeno{
  width: 20%;
  text-align: right;
  background-color: #bfd6f3;
  font-weight: bold;
}


input, select {
  margin: 0px;
  padding: 05px;
  width: 95%;
  height: 38px;
  font-family:'Montserrat', sans-serif;
  border: 1px solid lightgrey;
  border-radius: 05px;
  font-size: 0.9em;
}
input,select:focus{
   border: 1px solid #0e76fd;
  
}

</style>
