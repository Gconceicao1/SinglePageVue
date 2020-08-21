<template>
    <div>
        <titulo texto="Sobre"/>
            <p>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Velit modi consequatur, eveniet harum at recusandae a autem perferendis expedita rem pariatur, cupiditate incidunt vero laudantium nobis architecto ipsa similique eos?</p>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Non quisquam ipsa error atque maiores. 
                Dicta nesciunt, voluptatibus deleniti laudantium incidunt labore, impedit minus officia blanditiis omnis hic, 
                itaque nisi. Excepturi. Lorem ipsum dolor sit amet consectetur adipisicing elit. Aspernatur illum eaque illo placeat accusantium a ea similique numquam dolorum. 
                Enim vitae dolore corporis labore ullam neque dolor deserunt architecto sapiente!</p>
    </div>
</template>

<script>

    import titulo from '../_share/titulo'

    export default {

    components: {
        titulo,
    },

    data(){
        return{

        }
    }    
    }
</script>

<style scoped>
 p {
     text-align: justify;
 }
</style>